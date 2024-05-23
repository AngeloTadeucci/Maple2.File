using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Maple2.File.Generator.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Maple2.File.Generator;

[Generator]
public class XmlEnumGenerator : XmlGenerator {
    private static readonly SourceText attributeSource =
        Assembly.GetExecutingAssembly().LoadSource("M2dEnumAttribute.cs");
    private static readonly DiagnosticDescriptor typeError = new DiagnosticDescriptor(
        "FG00050",
        "M2dEnumAttribute can only be applied to System.Enum",
        "Invalid type {0} for M2dEnumAttribute in {1}",
        "Maple2.File.Generator",
        DiagnosticSeverity.Error,
        true
    );

    public XmlEnumGenerator() : base(attributeSource, "M2dXmlGenerator", "M2dEnum") { }

    protected override string ProcessClass(GeneratorExecutionContext context, ISymbol @class, IEnumerable<IFieldSymbol> fields, INamedTypeSymbol attribute) {
        var builder = new SourceBuilder(@class.ContainingNamespace);
        builder.Imports.AddRange(new[] {
            "System",
            "System.Xml.Serialization",
        });
        builder.Classes.AddRange(@class.ContainingTypes().Select(symbol => symbol.Name));
        builder.Classes.Add(@class.Name);

        // create properties for each field
        builder.Code.AddRange(fields.Select(field => ProcessField(context, field, attribute)));

        return builder.Build();
    }

    private string ProcessField(GeneratorExecutionContext context, IFieldSymbol field, ISymbol attribute) {
        INamedTypeSymbol enumSymbol = context.Compilation.GetTypeByMetadataName("System.Enum");
        if (!SymbolEqualityComparer.Default.Equals(field.Type.BaseType, enumSymbol)) {
            context.ReportDiagnostic(Diagnostic.Create(typeError, Location.None, field.Type, field.ToDisplayString()));
        }

        AttributeData attributeData = field.GetAttribute(attribute);
        string xmlAttributeName = attributeData.GetValueOrDefault("Name", field.Name);
        string fieldName = $"this.{field.Name}";

        var source = new StringBuilder();
        source.Append($@"
[XmlAttribute(""{xmlAttributeName}"")]
public string _{xmlAttributeName} {{
    get => {fieldName}.ToString();
    set {{
        if (int.TryParse(value, out int n)) {{
            if (System.Enum.IsDefined(typeof({field.Type}), n)) {{
                {fieldName} = ({field.Type}) n;
            }}
        }} else {{
            {fieldName} = System.Enum.Parse<{field.Type}>(value, true);
        }}
    }}
}}");
        return source.ToString();
    }
}
