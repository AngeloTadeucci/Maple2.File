using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Maple2.File.Parser.Flat;

namespace Maple2.File.Parser.MapXBlock.Generator;

public class PresetGenerator {
    private readonly FlatTypeIndex index;

    public PresetGenerator(FlatTypeIndex index) {
        this.index = index;
    }

    public void Run() {
        const string root = "flat/presets";
        IEnumerable<string> directories = index.Hierarchy.ListDirectories(root);
        foreach (string directoryLong in directories) {
            string directory = directoryLong.Replace("presets ", "");
            string path = $"Precompiled/{directory}";
            Directory.CreateDirectory(path);

            IEnumerable<FlatType> types = index.Hierarchy.List($"{root}/{directoryLong}");
            foreach (FlatType type in types) {
                // We expect all presets to be derivable from a library type.
                List<FlatType> requiredMixins = type.RequiredMixin().ToList();
                if (requiredMixins.Count != 1) {
                    // These cases may need to be manually handled.
                    Console.WriteLine($"Cannot find single mixin for \"{type}\"");
                    continue;
                }

                FlatType requiredMixin = requiredMixins.First();
                Type mixinType = ClassLookup.GetType($"I{requiredMixin.Name}");
                if (mixinType == null) {
                    Console.WriteLine($"Invalid type {type.Name} is not derived from library. Expected: {requiredMixin.Name}");
                }

                string filePath = Path.Combine(path, $"{type.Name}.cs");
                string code = GenerateClass(directory, type, mixinType);

                if (System.IO.File.Exists(filePath)) {
                    throw new InvalidOperationException("Attempting to overwrite file: " + filePath);
                }

                System.IO.File.WriteAllText(filePath, code);
                Console.WriteLine("Created file at: " + filePath);
            }
        }
    }

    public string GenerateClass(string @namespace, FlatType type, Type parent) {
        var builder = new StringBuilder();

        string className = ClassLookup.NormalizeClass(type.Name);
        builder.AppendLine($"namespace Maple2.File.Flat.Precompiled {{");
        builder.AppendLine($"\tinternal class {className} : {parent.Name} {{");

        builder.AppendLine($"\t\tpublic string ModelName {{ get; set; }} = \"{type.Name}\";");
        builder.AppendLine($"\t\tpublic string EntityId {{ get; set; }} = \"\";");
        builder.AppendLine($"\t\tpublic string EntityName {{ get; set; }} = \"\";");
        foreach (FlatProperty property in type.GetAllProperties()) {
            string typeStr = NormalizeType(property.Value.GetType().ToString());
            string typeValue = property.ValueCodeString();
            builder.AppendLine($"\t\tpublic {typeStr} {property.Name} {{ get; set; }} = {typeValue};");
        }

        builder.AppendLine("\t}"); // class
        builder.AppendLine("}"); // namespace
        builder.Replace("\t", "    ");

        var imports = new StringBuilder();
        string[] replaces = new[] {
            "System.Collections.Generic",
            "System.Drawing",
            "System.Numerics",
        };
        foreach (string replace in replaces) {
            int before = builder.Length;
            builder.Replace($"{replace}.", "");
            if (before != builder.Length) {
                imports.AppendLine($"using {replace};");
            }
        }
        imports.AppendLine($"using {parent.Namespace};");
        imports.AppendLine();

        return imports + builder.ToString();
    }

    private string NormalizeType(string type) {
        return Regex.Replace(type, "Dictionary`2\\[(.+)\\]", "IDictionary<$1>");
    }
}
