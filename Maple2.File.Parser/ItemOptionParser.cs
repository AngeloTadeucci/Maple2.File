using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml;
using Maple2.File.Parser.Xml.Table;

namespace Maple2.File.Parser;

public class ItemOptionParser {
    private readonly string[] constantSuffix = [
        "equip",
        "equip_fighter",
        "equip_pet",
        "equip_s2",
        "equipmanual",
        "etc",
        "gemstone",
        "mergematerial",
        "skin",
    ];
    private readonly string[] randomSuffix = {
        "12", "13", "14", "15", "16", "17", "18", "19",
        "20", "21", "22",
        "30", "31", "32", "33", "34",
        "40", "41",
        "50", "51", "52", "53", "54", "54_pvp", "55", "56",
        "accmanual",
        "armormanual",
        "pet_60",
        "weaponmanual",
    };
    private readonly string[] staticSuffix = {
        "12", "13", "14", "15", "16", "17", "18", "19",
        "20", "21", "22",
        "30", "31", "32", "33", "34",
        "40", "41",
        "50", "51", "52", "53", "54",
        "armormanual",
        "mergematerial",
        "petequipment",
    };
    private readonly string[] variationSuffix = [
        "acc",
        "armor",
        "pet",
        "weapon",
    ];

    private readonly M2dReader xmlReader;
    private readonly XmlSerializer itemOptionConstantSerializer;
    private readonly XmlSerializer itemOptionConstantKRSerializer;
    private readonly XmlSerializer itemOptionSerializer;
    private readonly XmlSerializer itemOptionKRSerializer;
    private readonly XmlSerializer itemMergeOptionKRSerializer;
    private readonly XmlSerializer itemMergeOptionSerializer;
    private readonly XmlSerializer itemOptionPickSerializer;
    private readonly XmlSerializer itemVariationSerializer;
    private readonly XmlSerializer itemVariationIndexSerializer;

    public ItemOptionParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        itemOptionConstantSerializer = new XmlSerializer(typeof(ItemOptionConstantRoot));
        itemOptionConstantKRSerializer = new XmlSerializer(typeof(ItemOptionConstantRootKR));
        itemOptionSerializer = new XmlSerializer(typeof(ItemOptionRoot));
        itemOptionKRSerializer = new XmlSerializer(typeof(ItemOptionRandomRootKR));
        itemMergeOptionKRSerializer = new XmlSerializer(typeof(ItemMergeOptionRootKR));
        itemMergeOptionSerializer = new XmlSerializer(typeof(ItemMergeOptionRoot));
        itemOptionPickSerializer = new XmlSerializer(typeof(ItemOptionPickRoot));
        itemVariationSerializer = new XmlSerializer(typeof(ItemOptionVariation));
        itemVariationIndexSerializer = new XmlSerializer(typeof(ItemOptionVariationEquip));
    }

    public IEnumerable<ItemOptionConstantData> ParseConstant() {
        foreach (string suffix in constantSuffix) {
            string filename = $"itemoption/constant/itemoptionconstant_{suffix}.xml";
            string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry(filename)));
            var reader = XmlReader.Create(new StringReader(xml));
            var root = itemOptionConstantSerializer.Deserialize(reader) as ItemOptionConstantRoot;
            Debug.Assert(root != null);

            foreach (ItemOptionConstantData option in root.option) {
                if (option.code > 0) {
                    yield return option;
                }
            }
        }
    }

    public IEnumerable<ItemOptionConstant> ParseConstantKR() {
        foreach (string suffix in constantSuffix) {
            string filename = "table/itemoptionconstant.xml";
            string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry(filename)));
            xml = Sanitizer.RemoveUtf8Bom(xml);
            var reader = XmlReader.Create(new StringReader(xml));
            var root = itemOptionConstantKRSerializer.Deserialize(reader) as ItemOptionConstantRootKR;
            Debug.Assert(root != null);

            foreach (ItemOptionConstant option in root.options) {
                if (option.code > 0) {
                    yield return option;
                }
            }
        }
    }

    public IEnumerable<ItemOptionData> ParseRandom() {
        foreach (string suffix in randomSuffix) {
            string filename = $"itemoption/option/random/itemoptionrandom_{suffix}.xml";
            string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry(filename)));
            var reader = XmlReader.Create(new StringReader(xml));
            var root = itemOptionSerializer.Deserialize(reader) as ItemOptionRoot;
            Debug.Assert(root != null);

            foreach (ItemOptionData option in root.option) {
                if (option.code > 0) {
                    yield return option;
                }
            }
        }
    }

    public IEnumerable<ItemOptionRandomKR> ParseRandomKR() {
        foreach (string suffix in randomSuffix) {
            string filename = "table/itemoptionrandom.xml";
            string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry(filename)));
            xml = Sanitizer.RemoveUtf8Bom(xml);
            var reader = XmlReader.Create(new StringReader(xml));
            var root = itemOptionKRSerializer.Deserialize(reader) as ItemOptionRandomRootKR;
            Debug.Assert(root != null);

            foreach (ItemOptionRandomKR option in root.options) {
                if (option.code > 0) {
                    yield return option;
                }
            }
        }
    }

    public IEnumerable<ItemOptionData> ParseStatic() {
        foreach (string suffix in staticSuffix) {
            string filename = $"itemoption/option/static/itemoptionstatic_{suffix}.xml";
            string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry(filename)));
            var reader = XmlReader.Create(new StringReader(xml));
            var root = itemOptionSerializer.Deserialize(reader) as ItemOptionRoot;
            Debug.Assert(root != null);

            foreach (ItemOptionData option in root.option) {
                if (option.code > 0) {
                    yield return option;
                }
            }
        }
    }

    public IEnumerable<MergeOptionKR> ParseMergeOptionBaseKR() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/itemmergeoptionbase.xml")));
        xml = Sanitizer.RemoveUtf8Bom(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var root = itemMergeOptionKRSerializer.Deserialize(reader) as ItemMergeOptionRootKR;
        Debug.Assert(root != null);

        foreach (MergeOptionKR option in root.mergeOption) {
            yield return option;
        }
    }

    public IEnumerable<MergeOption> ParseMergeOptionBase() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/itemmergeoptionbase.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var root = itemMergeOptionSerializer.Deserialize(reader) as ItemMergeOptionRoot;
        Debug.Assert(root != null);

        foreach (MergeOption option in root.mergeOption) {
            yield return option;
        }
    }

    public IEnumerable<MergeOption> ParseMergeOptionMaterial() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/itemmergeoptionmaterial.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var root = itemMergeOptionSerializer.Deserialize(reader) as ItemMergeOptionRoot;
        Debug.Assert(root != null);

        foreach (MergeOption option in root.mergeOption) {
            yield return option;
        }
    }

    public IEnumerable<ItemOptionPick> ParsePick() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/itemoptionpick.xml"));
        var root = itemOptionPickSerializer.Deserialize(reader) as ItemOptionPickRoot;
        Debug.Assert(root != null);

        foreach (ItemOptionPick pick in root.itemOptionPick) {
            yield return pick;
        }
    }

    public IEnumerable<ItemOptionVariation.Option> ParseVariation() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/itemoptionvariation.xml"));
        var data = itemVariationSerializer.Deserialize(reader) as ItemOptionVariation;
        Debug.Assert(data != null);

        foreach (ItemOptionVariation.Option option in data.option) {
            yield return option;
        }
    }

    public IEnumerable<(string Type, List<ItemOptionVariationEquip.Option> Option)> ParseVariationEquip() {
        foreach (string suffix in variationSuffix) {
            string filename = $"table/itemoptionvariation_{suffix}.xml";
            XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry(filename));
            var data = itemVariationIndexSerializer.Deserialize(reader) as ItemOptionVariationEquip;
            Debug.Assert(data != null);

            var options = new List<ItemOptionVariationEquip.Option>();
            foreach (ItemOptionVariationEquip.Option option in data.option) {
                options.Add(option);
            }
            yield return (suffix, options);
        }
    }
}
