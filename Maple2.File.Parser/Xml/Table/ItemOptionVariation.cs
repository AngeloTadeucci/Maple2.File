using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/itemoptionvariation.xml
[XmlRoot("ms2")]
public partial class ItemOptionVariation {
    [M2dFeatureLocale(Selector = "OptionName|OptionRateMin|OptionRateMax|OptionValueMin|OptionValueMax")] private IList<Option> _option;

    public partial class Option : IFeatureLocale {
        [XmlAttribute] public string OptionName = string.Empty;
        [XmlAttribute] public float OptionRateMin;
        [XmlAttribute] public float OptionRateMax;
        [XmlAttribute] public float OptionRateVariation;
        [XmlAttribute] public int OptionValueMin;
        [XmlAttribute] public int OptionValueMax;
        [XmlAttribute] public int OptionValueVariation;
    }
}

// ./data/xml/table/itemoptionvariation_%s.xml
[XmlRoot("ms2")]
public class ItemOptionVariationEquip {
    [XmlElement] public List<Option> option;

    public class Option {
        [XmlAttribute] public string name = string.Empty;
        [XmlAttribute] public float idx0;
        [XmlAttribute] public float idx1;
        [XmlAttribute] public float idx2;
        [XmlAttribute] public float idx3;
        [XmlAttribute] public float idx4;
        [XmlAttribute] public float idx5;
        [XmlAttribute] public float idx6;
        [XmlAttribute] public float idx7;
        [XmlAttribute] public float idx8;
        [XmlAttribute] public float idx9;
        [XmlAttribute] public float idx10;
        [XmlAttribute] public float idx11;
        [XmlAttribute] public float idx12;
        [XmlAttribute] public float idx13;
        [XmlAttribute] public float idx14;
        [XmlAttribute] public float idx15;
        [XmlAttribute] public float idx16;
        [XmlAttribute] public float idx17;

        public float this[int i] => i switch {
            0 => idx0,
            1 => idx1,
            2 => idx2,
            3 => idx3,
            4 => idx4,
            5 => idx5,
            6 => idx6,
            7 => idx7,
            8 => idx8,
            9 => idx9,
            10 => idx10,
            11 => idx11,
            12 => idx12,
            13 => idx13,
            14 => idx14,
            15 => idx15,
            16 => idx16,
            17 => idx17,
            _ => throw new ArgumentOutOfRangeException(nameof(i), i, "Invalid option index."),
        };
    }
}
