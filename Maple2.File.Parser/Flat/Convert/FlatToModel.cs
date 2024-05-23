using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;

namespace Maple2.File.Parser.Flat.Convert;

public class FlatToModel {
    private readonly FlatTypeIndex index;
    private readonly AssetIndex assetIndex;
    private readonly XmlSerializer serializer;
    private readonly XmlSerializer presetSerializer;
    private readonly XmlSerializerNamespaces xmlNamespace;

    // These files are .preset equivalents so we don't need to generate .model
    private readonly HashSet<string> ignorePreset = new() {
        "spotlight00",
        "spotlight01",
        "pointlight00",
        "pointlight01",
        "pointlight02",
        "directionallight00",
        "directionallight01",
        "directionallight02",
        "beastqualitypresetpreviewgi",
        "beastqualitypresetpreviewnogi",
        "beastqualitypresetproductiongi",
        "beastqualitysettings_preset_previewgi",
        "beastqualitysettings_preset_previewnogi",
        "beastqualitysettings_preset_productiongi",
    };

    public FlatToModel(M2dReader reader, M2dReader assetReader, string root = "flat") {
        index = new FlatTypeIndex(reader, root);
        assetIndex = new AssetIndex(assetReader);
        serializer = new XmlSerializer(typeof(EntityModel));
        presetSerializer = new XmlSerializer(typeof(EntityModelPreset));
        xmlNamespace = new XmlSerializerNamespaces();
        xmlNamespace.Add(string.Empty, string.Empty);
    }

    public void Convert() {
        foreach (FlatType type in index.GetAllTypes()) {
            if (ignorePreset.Contains(type.Name.ToLower())) {
                Console.WriteLine($"Ignoring preset: {type.Name}");
                continue;
            }

            string ext = "";
            bool isPreset = false;
            if (type.Path.StartsWith("flat/library")) {
                ext = "model";
            } else if (type.Path.StartsWith("flat/presets")) {
                ext = "preset";
                isPreset = true;
            }
            string path = Path.GetDirectoryName(type.Path.Replace("flat/", "convert/")) ?? string.Empty;

            EntityModel model = Convert(type, isPreset);
            Directory.CreateDirectory(path);
            var writer = new XmlTextWriter(new StreamWriter($"{path}/{type.Name}.{ext}", false, Encoding.UTF8));
            writer.Formatting = Formatting.Indented;
            if (isPreset) {
                presetSerializer.Serialize(writer, model, xmlNamespace);
            } else {
                serializer.Serialize(writer, model, xmlNamespace);
            }
            //Console.WriteLine($"Created {name}");
        }
    }

    private EntityModel Convert(FlatType type, bool isPreset) {
        EntityModel model = isPreset ? new EntityModelPreset() : new EntityModel();
        model.Id = type.ToGuid().ToString();

        List<FlatType> requiredMixin = type.RequiredMixin().ToList();
        model.Mixins.Mixin = requiredMixin.Select(mixin => new Mixin {
            SourceId = mixin.ToGuid().ToString(),
            SourceName = mixin.Name,
        }).ToList();

        model.Properties.Property = type.GetNewProperties().Select(prop => new Property {
            Name = prop.Name,
            Value = new Value(assetIndex, prop.Type, prop.Value),
            Traits = new LTraits {
                Trait = prop.Trait.Select(trait => new Trait { Name = trait }).ToList(),
            },
        }).ToList();
        // PropertyOverrides
        foreach (FlatProperty property in type.GetAllProperties()) {
            bool overridden = false;
            var propOverride = new PropertyOverride { Name = property.Name };

            foreach (FlatType mixin in requiredMixin) {
                FlatProperty mixinProperty = mixin.GetProperty(property.Name);
                if (mixinProperty == null) {
                    continue;
                }

                if (!mixinProperty.ValueEquals(property.Value)) {
                    overridden = true;
                    propOverride.Value = new Value(assetIndex, property.Type, property.Value);
                }

                if (!mixinProperty.Trait.SequenceEqual(property.Trait)) {
                    overridden = true;
                    foreach (string trait in property.Trait.Concat(mixinProperty.Trait).Distinct()) {
                        bool inMixin = mixinProperty.Trait.Contains(trait);
                        bool inProp = property.Trait.Contains(trait);
                        if (inMixin != inProp) {
                            propOverride.TraitOverrides.TraitOverride.Add(new TraitOverride {
                                IsActive = !inMixin,
                                Trait = new Trait { Name = trait },
                            });
                        }
                    }
                }
            }

            if (overridden) {
                model.PropertyOverrides.PropertyOverride.Add(propOverride);
            }
        }

        model.Behaviors.Behavior = type.GetNewBehaviors().Select(behavior => new Behavior {
            Name = behavior.Name,
            Target = behavior.Type,
            Traits = new LTraits {
                Trait = behavior.Trait.Select(trait => new Trait { Name = trait }).ToList(),
            },
        }).ToList();
        // TODO: BehaviorOverrides
        // foreach (FlatBehavior behavior in type.GetAllBehaviors()) {
        //     bool overridden = false;
        //     var behaviorOverride = new BehaviorOverride {Name = behavior.Name};
        //
        //     foreach (FlatType mixin in requiredMixin) {
        //         FlatBehavior mixinBehavior = mixin.GetBehavior(behavior.Name);
        //         if (mixinBehavior == null) {
        //             continue;
        //         }
        //
        //         if (!mixinBehavior.ValueEquals(behavior.Value)) {
        //             overridden = true;
        //             propOverride.Value = new Value(behavior.Type, behavior.Value);
        //         }
        //
        //         if (!mixinBehavior.Trait.SequenceEqual(behavior.Trait)) {
        //             overridden = true;
        //             foreach (string trait in behavior.Trait.Concat(mixinBehavior.Trait).Distinct()) {
        //                 bool inMixin = mixinBehavior.Trait.Contains(trait);
        //                 bool inProp = behavior.Trait.Contains(trait);
        //                 if (inMixin != inProp) {
        //                     propOverride.TraitOverrides.TraitOverride.Add(new TraitOverride {
        //                         IsActive = !inMixin,
        //                         Trait = new Trait{Name = trait},
        //                     });
        //                 }
        //             }
        //         }
        //     }
        // }

        model.Traits = new LTraits {
            Trait = type.Trait.Select(trait => new Trait { Name = trait }).ToList(),
        };

        return model;
    }
}
