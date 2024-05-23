using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Maple2.File.Generator.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Maple2.File.Generator;

[Generator]
public class XmlColorGenerator : XmlGenerator {
    private static readonly SourceText attributeSource =
        Assembly.GetExecutingAssembly().LoadSource("M2dColorAttribute.cs");
    private static readonly DiagnosticDescriptor typeError = new DiagnosticDescriptor(
        "FG00060",
        "M2dColorAttribute can only be applied to System.Drawing.Color",
        "Invalid type {0} for M2dColorAttribute in {1}",
        "Maple2.File.Generator",
        DiagnosticSeverity.Error,
        true
    );

    public XmlColorGenerator() : base(attributeSource, "M2dXmlGenerator", "M2dColor") { }

    protected override string ProcessClass(GeneratorExecutionContext context, ISymbol @class,
        IEnumerable<IFieldSymbol> fields, INamedTypeSymbol attribute) {
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
        if (field.Type.ToDisplayString() != "System.Drawing.Color") {
            context.ReportDiagnostic(Diagnostic.Create(typeError, Location.None, field.Type, field.ToDisplayString()));
        }

        AttributeData attributeData = field.GetAttribute(attribute);
        string xmlAttributeName = attributeData.GetValueOrDefault("Name", field.Name);
        string fieldName = $"this.{field.Name}";

        var source = new StringBuilder();
        source.Append($@"
[XmlAttribute(""{xmlAttributeName}"")]
public string _{xmlAttributeName} {{
    get => $""0x{{{fieldName}.A:x2}}{{{fieldName}.R:x2}}{{{fieldName}.G:x2}}{{{fieldName}.B:x2}}"";
    set => {fieldName} = System.Drawing.Color.FromArgb(Convert.ToInt32(value, 16));
}}");
        return source.ToString();
    }
}
