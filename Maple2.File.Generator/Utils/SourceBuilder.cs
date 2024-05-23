using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Maple2.File.Generator.Utils;

internal class SourceBuilder {
    private readonly INamespaceSymbol @namespace;
    public readonly List<string> Imports;
    public readonly List<string> Classes;
    public readonly List<string> Code;

    public SourceBuilder(INamespaceSymbol namespaceSymbol) {
        @namespace = namespaceSymbol;
        Imports = new List<string>();
        Classes = new List<string>();
        Code = new List<string>();
    }

    public string Build() {
        var builder = new StringBuilder();
        foreach (string import in Imports) {
            builder.AppendLine($"using {import};");
        }

        builder.AppendLine($"namespace {@namespace.ToDisplayString()} {{");
        foreach (string @class in Classes) {
            builder.AppendLine($"public partial class {@class} {{");
        }

        // Class Body
        foreach (string code in Code) {
            builder.AppendLine(code);
        }

        foreach (string _ in Classes) {
            builder.AppendLine("}");
        }

        builder.AppendLine("}"); // namespace
        return builder.ToString();
    }
}
