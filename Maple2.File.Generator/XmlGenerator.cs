using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maple2.File.Generator.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Maple2.File.Generator;

public abstract class XmlGenerator : ISourceGenerator {
    private readonly SourceText attributeSource;

    protected readonly string attributeNamespace;
    protected readonly string attributeTag;
    protected string attributeName => attributeTag + "Attribute";

    public XmlGenerator(SourceText attributeSource, string attributeNamespace, string attributeTag) {
        this.attributeSource = attributeSource;
        this.attributeNamespace = attributeNamespace;
        this.attributeTag = attributeTag;
    }

    public void Initialize(GeneratorInitializationContext context) {
        // Register a syntax receiver that will be created for each generation pass
        context.RegisterForSyntaxNotifications(() => new AttributeSyntaxReceiver());
    }

    public virtual void Execute(GeneratorExecutionContext context) {
        // if (!Debugger.IsAttached) {
        //     Debugger.Launch();
        // }
        // Register the attribute source
        context.AddSource(attributeName, attributeSource);

        if (context.SyntaxReceiver is not AttributeSyntaxReceiver receiver) {
            return;
        }

        Compilation compilation = context.Compilation.AddSource(attributeSource.ToString());
        INamedTypeSymbol attributeSymbol = compilation.GetTypeByMetadataName($"{attributeNamespace}.{attributeName}");

        IEnumerable<IGrouping<ISymbol, IFieldSymbol>> classGroups = receiver.Fields
            .Fields(compilation)
            .WithAttribute(attributeSymbol)
            .GroupBy(field => field.ContainingType, SymbolEqualityComparer.Default);

        foreach (IGrouping<ISymbol, IFieldSymbol> group in classGroups) {
            var hintName = new StringBuilder($"[{group.Key.ContainingNamespace.Name}]");
            foreach (INamedTypeSymbol containingType in group.Key.ContainingTypes()) {
                hintName.Append($"{containingType.Name}.");
            }

            hintName.Append($"{group.Key.Name}_{attributeTag}.cs");

            string classSource = ProcessClass(context, group.Key, group, attributeSymbol);
            context.AddSource(hintName.ToString(), SourceText.From(classSource, Encoding.UTF8));
        }
    }

    protected abstract string ProcessClass(GeneratorExecutionContext context, ISymbol @class,
        IEnumerable<IFieldSymbol> fields, INamedTypeSymbol attribute);
}
