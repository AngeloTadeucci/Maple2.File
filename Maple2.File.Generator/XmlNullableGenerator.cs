using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Maple2.File.Generator.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Maple2.File.Generator;

[Generator]
public class XmlNullableGenerator : XmlGenerator {
    private static readonly SourceText attributeSource =
        Assembly.GetExecutingAssembly().LoadSource("M2dNullableAttribute.cs");
    private static readonly DiagnosticDescriptor typeError = new DiagnosticDescriptor(
        "FG00020",
        "M2dNullableAttribute can only be applied to nullable value types",
        "Invalid type {0} for M2dNullableAttribute in {1}",
        "Maple2.File.Generator",
        DiagnosticSeverity.Error,
        true
    );

    public XmlNullableGenerator() : base(attributeSource, "M2dXmlGenerator", "M2dNullable") { }

    protected override string ProcessClass(GeneratorExecutionContext context, ISymbol @class,
        IEnumerable<IFieldSymbol> fields, INamedTypeSymbol attribute) {
        var builder = new SourceBuilder(@class.ContainingNamespace);
        builder.Imports.AddRange(new[] {
            "System.ComponentModel",
            "System.Xml.Serialization",
        });
        builder.Classes.AddRange(@class.ContainingTypes().Select(symbol => symbol.Name));
        builder.Classes.Add(@class.Name);

        // create properties for each field
        builder.Code.AddRange(fields.Select(field => ProcessField(context, field, attribute)));

        return builder.Build();
    }

    private string ProcessField(GeneratorExecutionContext context, IFieldSymbol field, ISymbol attribute) {
        if (!IsNullableValue(field)) {
            context.ReportDiagnostic(Diagnostic.Create(typeError, Location.None, field.Type, field.ToDisplayString()));
        }

        AttributeData attributeData = field.GetAttribute(attribute);
        string xmlAttributeName = attributeData.GetValueOrDefault("Name", field.Name);
        string fieldName = $"this.{field.Name}";
        string valueType = field.Type.ToDisplayString().TrimEnd('?');

        return $@"
[XmlAttribute(""{xmlAttributeName}""), DefaultValue(null)]
public string _{xmlAttributeName} {{
    get => {fieldName}?.ToString();
    set => {fieldName} = {valueType}.TryParse(value, out {valueType} n) ? ({field.Type}) n : null;
}}";
    }

    private static bool IsNullableValue(IFieldSymbol field) {
        return field.Type.IsValueType && field.NullableAnnotation == NullableAnnotation.Annotated;
    }
}
