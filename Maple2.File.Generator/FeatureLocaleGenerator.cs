using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Maple2.File.Generator.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Maple2.File.Generator;

[Generator]
public class FeatureLocaleGenerator : ISourceGenerator {
    private static readonly SourceText featureLocaleSource =
        Assembly.GetExecutingAssembly().LoadSource("IFeatureLocale.cs");

    public void Initialize(GeneratorInitializationContext context) {
        // Register a syntax receiver that will be created for each generation pass
        context.RegisterForSyntaxNotifications(() => new ClassSyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext context) {
        // Register the interface source
        context.AddSource("IFeatureLocale", featureLocaleSource);

        if (!(context.SyntaxReceiver is ClassSyntaxReceiver receiver)) {
            return;
        }

        Compilation compilation = context.Compilation.AddSource(featureLocaleSource.ToString());
        INamedTypeSymbol interfaceSymbol = compilation.GetTypeByMetadataName("M2dXmlGenerator.IFeatureLocale");

        IEnumerable<ITypeSymbol> classes = receiver.Classes
            .WithInterface(compilation, interfaceSymbol);

        foreach (ITypeSymbol @class in classes) {
            var hintName = new StringBuilder($"[{@class.ContainingNamespace.Name}]");
            foreach (INamedTypeSymbol containingType in @class.ContainingTypes()) {
                hintName.Append($"{containingType.Name}.");
            }

            hintName.Append($"{@class.Name}_IFeatureLocale.cs");

            var builder = new SourceBuilder(@class.ContainingNamespace);
            builder.Imports.Add("System.Xml.Serialization");
            builder.Classes.AddRange(@class.ContainingTypes().Select(symbol => symbol.Name));
            builder.Classes.Add(@class.Name);
            builder.Code.Add(@"[XmlAttribute(""feature"")] public string _feature = string.Empty;");
            builder.Code.Add(@"[XmlAttribute(""locale"")] public string _locale = string.Empty;");
            builder.Code.Add(@"public string Feature => _feature;");
            builder.Code.Add(@"public string Locale => _locale;");

            context.AddSource(hintName.ToString(), SourceText.From(builder.Build(), Encoding.UTF8));
        }
    }
}
