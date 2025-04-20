using System.Reflection;
using System.Text;
using Maple2.File.Generator.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Maple2.File.Generator;

[Generator]
public class XmlArrayGenerator : XmlGenerator {
    private static readonly SourceText attributeSource =
        Assembly.GetExecutingAssembly().LoadSource("M2dArrayAttribute.cs");
    private static readonly DiagnosticDescriptor typeError = new DiagnosticDescriptor(
        "FG00010",
        "M2dArrayAttribute can only be applied to value array types",
        "Invalid type {0} for M2dArrayAttribute in {1}",
        "Maple2.File.Generator",
        DiagnosticSeverity.Error,
        true
    );

    public XmlArrayGenerator() : base(attributeSource, "M2dXmlGenerator", "M2dArray") { }

    protected override string ProcessClass(GeneratorExecutionContext context, ISymbol @class,
        IEnumerable<IFieldSymbol> fields, INamedTypeSymbol attribute) {
        var builder = new SourceBuilder(@class.ContainingNamespace);
        builder.Imports.AddRange([
            "System",
            "System.Xml.Serialization",
        ]);
        builder.Classes.AddRange(@class.ContainingTypes().Select(symbol => symbol.Name));
        builder.Classes.Add(@class.Name);

        // create properties for each field
        builder.Code.AddRange(fields.Select(field => ProcessField(context, field, attribute)));

        return builder.Build();
    }

    private string ProcessField(GeneratorExecutionContext context, IFieldSymbol field, ISymbol attribute) {
        if (!(field.Type is IArrayTypeSymbol)) {
            context.ReportDiagnostic(Diagnostic.Create(typeError, Location.None, field.Type, field.ToDisplayString()));
        }

        AttributeData attributeData = field.GetAttribute(attribute);
        string xmlAttributeName = attributeData.GetValueOrDefault("Name", field.Name);
        char delimiter = attributeData.GetValueOrDefault<char>("Delimiter", ',');
        bool keepEmpty = attributeData.GetValueOrDefault<bool>("KeepEmpty", false);

        var source = new StringBuilder();
        source.Append($@"
[XmlAttribute(""{xmlAttributeName}"")]
public string _{xmlAttributeName} {{
    get {{
");
        AddSerializer(source, field, delimiter);
        source.Append(@"
    }
    set {");
        AddDeserializer(context, source, field, delimiter, keepEmpty);
        source.AppendLine(@"
    }
}");
        return source.ToString();
    }

    private void AddSerializer(StringBuilder source, IFieldSymbol field, char delimiter) {
        string fieldName = $"this.{field.FieldName()}";
        source.Append(@$"       return {fieldName} != null ? string.Join('{delimiter}', {fieldName}) : string.Empty;");
    }

    private void AddDeserializer(GeneratorExecutionContext context, StringBuilder source, IFieldSymbol field, char delimiter, bool keepEmpty) {
        var arrayType = field.Type as IArrayTypeSymbol;

        string fieldName = $"this.{field.FieldName()}";
        if (keepEmpty) {
            source.AppendLine($@"
string[] split = value.Split('{delimiter}');");
        } else {
            source.AppendLine($@"
string[] split = value.Split('{delimiter}', StringSplitOptions.RemoveEmptyEntries);");
        }

        source.AppendLine($@"
{fieldName} = new {arrayType.ElementType}[split.Length];
for (int i = 0; i < split.Length; i++) {{
    var val = split[i].Trim();");

        INamedTypeSymbol enumSymbol = context.Compilation.GetTypeByMetadataName("System.Enum");
        if (SymbolEqualityComparer.Default.Equals(arrayType.ElementType.BaseType, enumSymbol)) {
            source.Append($@"
if (int.TryParse(val, out int n)) {{
    if (System.Enum.IsDefined(typeof({arrayType.ElementType}), n)) {{
        {fieldName}[i] = ({arrayType.ElementType}) n;
    }}
}} else {{
    {fieldName}[i] = System.Enum.Parse<{arrayType.ElementType}>(val, true);
}}
");
        } else if (arrayType.ElementType.IsValueType) {
            if (arrayType.ElementType.ToString() == "bool") {
                source.AppendLine($@"{fieldName}[i] = bool.TryParse(val, out bool result) ? result : (val != ""0"");");
            } else {
                source.AppendLine($"{fieldName}[i] = {arrayType.ElementType}.Parse(val);");
            }
        } else {
            source.AppendLine($"{fieldName}[i] = val;");
        }
        source.Append('}');
    }
}
