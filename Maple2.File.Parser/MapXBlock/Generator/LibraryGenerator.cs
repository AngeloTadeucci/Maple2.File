using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Maple2.File.Parser.Flat;

namespace Maple2.File.Parser.MapXBlock.Generator;

public class LibraryGenerator {
    private readonly FlatTypeIndex index;

    public LibraryGenerator(FlatTypeIndex index) {
        this.index = index;
    }

    public void Run() {
        const string root = "flat/library";
        IEnumerable<string> directories = index.Hierarchy.ListDirectories(root);
        foreach (string directory in directories) {
            string path = $"Library/{directory}";
            Directory.CreateDirectory(path);

            IEnumerable<FlatType> types = index.Hierarchy.List($"{root}/{directory}");
            foreach (FlatType type in types) {
                /*string filePath;
                string code;
                if (Index.GetSubTypes(type.Name.ToLower()).Count == 0) {
                    filePath = Path.Combine(path, $"{type.Name}.cs");
                    code = GenerateClass(directory, type);
                } else {
                    filePath = Path.Combine(path, $"I{type.Name}.cs");
                    code = GenerateInterface(directory, type);
                }*/

                // Generating all interfaces for now
                string filePath = Path.Combine(path, $"I{type.Name}.cs");
                string code = GenerateInterface(directory, type);

                if (System.IO.File.Exists(filePath)) {
                    throw new InvalidOperationException("Attempting to overwrite file: " + filePath);
                }

                System.IO.File.WriteAllText(filePath, code);
                Console.WriteLine("Created file at: " + filePath);
            }
        }
    }

    public void ValidatePresets() {
        const string root = "flat/presets";
        IEnumerable<string> directories = index.Hierarchy.ListDirectories(root);
        foreach (string directory in directories) {
            IEnumerable<FlatType> types = index.Hierarchy.List($"{root}/{directory}");
            foreach (FlatType type in types) {
                // We expect all presets to be derivable from a library type.
                List<FlatType> requiredMixins = type.RequiredMixin().ToList();
                if (requiredMixins.Count != 1) {
                    throw new InvalidOperationException($"Cannot find single mixin for \"{type}\"");
                }

                FlatType requiredMixin = requiredMixins.First();
                Type mixinType = ClassLookup.GetType($"I{requiredMixin.Name}");
                if (mixinType == null) {
                    Console.WriteLine($"Invalid type {type.Name} is not derived from library. Expected: {requiredMixin.Name}");
                }
            }
        }
    }

    public string GenerateInterface(string @namespace, FlatType type) {
        List<string> mixinTypes = type.RequiredMixin()
            .Select(mixin => mixin.Name)
            .ToList();
        var inheritedProperties = new Dictionary<string, object>();
        foreach (string mixinType in mixinTypes) {
            foreach (FlatProperty property in index.GetType(mixinType).GetAllProperties()) {
                if (inheritedProperties.ContainsKey(property.Name)) {
                    inheritedProperties[property.Name] = null;
                } else {
                    inheritedProperties.Add(property.Name, property.Value);
                }
            }
        }

        var builder = new StringBuilder();

        builder.AppendLine($"namespace Maple2.File.Flat.{@namespace} {{");

        List<string> mixinInterfaces = mixinTypes.Select(mixin => $"I{mixin}").ToList();
        if (mixinInterfaces.Count > 0) {
            builder.AppendLine($"\tpublic interface I{type.Name} : {string.Join(",", mixinInterfaces)} {{");
        } else {
            builder.AppendLine($"\tpublic interface I{type.Name} : IMapEntity {{");
        }

        builder.AppendLine($"\t\tstring ModelName => \"{type.Name}\";");
        foreach (FlatProperty property in type.GetProperties()) {
            // Inherited properties don't need to be declared on interface
            if (inheritedProperties.TryGetValue(property.Name, out object propertyValue)) {
                if (propertyValue != null) {
                    if (property.ValueEquals(propertyValue)) {
                        continue;
                    }
                }
            }

            string typeStr = NormalizeType(property.Value.GetType().ToString());
            string typeValue = property.ValueCodeString();
            builder.AppendLine($"\t\t{typeStr} {property.Name} => {typeValue};");
        }

        builder.AppendLine("\t}"); // class
        builder.AppendLine("}"); // namespace

        return builder.ToString();
    }

    private string NormalizeType(string type) {
        return Regex.Replace(type, "Dictionary`2\\[(.+)\\]", "IDictionary<$1>");
    }
}
