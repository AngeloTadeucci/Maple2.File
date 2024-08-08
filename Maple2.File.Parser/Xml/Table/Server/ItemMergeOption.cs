using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/itemMergeOptionBase.xml
[XmlRoot("ms2")]
public class ItemMergeOptionRoot {
    [XmlElement] public List<MergeOption> mergeOption;
}

public partial class MergeOption : IFeatureLocale {
    [XmlAttribute] public int id;

    [XmlElement] public List<Slot> slot;

    public partial class Slot {
        [XmlAttribute] public int part = 1;
        [XmlAttribute] public long consumeMeso;
        [M2dArray] public string[] itemMaterial1 = Array.Empty<string>();
        [M2dArray] public string[] itemMaterial2 = Array.Empty<string>();
        [XmlElement] public List<Option> option;
    }

    public partial class Option {
        [XmlAttribute] public string optionName = string.Empty;
        [XmlAttribute] public int min;
        [XmlAttribute] public int idx0_max;
        [XmlAttribute] public int idx0_weight;
        [XmlAttribute] public int idx1_max;
        [XmlAttribute] public int idx1_weight;
        [XmlAttribute] public int idx2_max;
        [XmlAttribute] public int idx2_weight;
        [XmlAttribute] public int idx3_max;
        [XmlAttribute] public int idx3_weight;
        [XmlAttribute] public int idx4_max;
        [XmlAttribute] public int idx4_weight;
        [XmlAttribute] public int idx5_max;
        [XmlAttribute] public int idx5_weight;
        [XmlAttribute] public int idx6_max;
        [XmlAttribute] public int idx6_weight;
        [XmlAttribute] public int idx7_max;
        [XmlAttribute] public int idx7_weight;
        [XmlAttribute] public int idx8_max;
        [XmlAttribute] public int idx8_weight;
        [XmlAttribute] public int idx9_max;
        [XmlAttribute] public int idx9_weight;
    }
}
