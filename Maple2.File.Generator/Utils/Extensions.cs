using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Maple2.File.Generator.Utils;

internal static class Extensions {
    public static Compilation AddSource(this Compilation compilation, string source) {
        var options = (compilation as CSharpCompilation)?.SyntaxTrees[0].Options as CSharpParseOptions;
        SyntaxTree attributeSyntaxTree =
            CSharpSyntaxTree.ParseText(SourceText.From(source, Encoding.UTF8), options);
        return compilation.AddSyntaxTrees(attributeSyntaxTree);
    }

    public static AttributeData GetAttribute(this IFieldSymbol field, ISymbol attribute) {
        return field.GetAttributes()
            .SingleOrDefault(data => SymbolEqualityComparer.Default.Equals(data.AttributeClass, attribute));
    }

    public static T GetValueOrDefault<T>(this AttributeData data, string name, T @default) {
        TypedConstant constant = data.NamedArguments.SingleOrDefault(pair => pair.Key == name).Value;
        if (constant.Value is T value) {
            return value;
        }

        return @default;
    }

    public static string FieldName(this IFieldSymbol field) {
        string displayString = field.ToDisplayString();
        return displayString.Substring(displayString.LastIndexOf('.') + 1);
    }

    public static IList<INamedTypeSymbol> ContainingTypes(this ISymbol symbol) {
        List<INamedTypeSymbol> containingTypes = new List<INamedTypeSymbol>();
        INamedTypeSymbol containingType = symbol.ContainingType;
        while (containingType != null) {
            containingTypes.Add(containingType);
            containingType = containingType.ContainingType;
        }

        containingTypes.Reverse();
        return containingTypes;
    }

    public static IEnumerable<IFieldSymbol> Fields(this IEnumerable<FieldDeclarationSyntax> fields,
        Compilation compilation) {
        return fields.SelectMany(field => {
            SemanticModel model = compilation.GetSemanticModel(field.SyntaxTree);
            return field.Declaration.Variables
                .Select(variable => model.GetDeclaredSymbol(variable))
                .Cast<IFieldSymbol>();
        });
    }

    public static IEnumerable<IFieldSymbol> WithAttribute(this IEnumerable<IFieldSymbol> symbols,
        INamedTypeSymbol attributeSymbol) {
        return symbols.Where(symbol => symbol.GetAttribute(attributeSymbol) != null);
    }

    public static IEnumerable<INamedTypeSymbol> WithInterface(
        this IEnumerable<ClassDeclarationSyntax> classes, Compilation compilation, INamedTypeSymbol interfaceSymbol) {
        return classes.Where(@class => @class.BaseList != null)
            .Where(@class => {
                SemanticModel model = compilation.GetSemanticModel(@class.SyntaxTree);
                return @class.BaseList.Types
                    .Select(type => type.Type)
                    .Select(type => model.GetTypeInfo(type))
                    .Select(info => info.Type)
                    .Any(type => SymbolEqualityComparer.Default.Equals(type, interfaceSymbol));
            }).Select(@class => compilation.GetSemanticModel(@class.SyntaxTree).GetDeclaredSymbol(@class));
    }

    public static SourceText LoadSource(this Assembly assembly, string fileName) {
        string resourceName = $"Maple2.File.Generator.Resource.{fileName}";
        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        using (var reader = new StreamReader(stream)) {
            return SourceText.From(reader.ReadToEnd(), Encoding.UTF8);
        }
    }
}
