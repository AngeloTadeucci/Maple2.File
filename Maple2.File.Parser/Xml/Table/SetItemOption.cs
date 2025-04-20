using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Xml.Common;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/setitemoption.xml
[XmlRoot("ms2")]
public partial class SetItemOptionRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<SetItemOption> _option;
}

public partial class SetItemOption : IFeatureLocale {
    [XmlAttribute] public int id;

    [M2dFeatureLocale(Selector = "count")] private IList<Part> _part;

    public partial class Part : ItemOption, IFeatureLocale {
        [XmlAttribute] public int count;
        [M2dArray] public int[] additionalEffectID;
        [M2dArray] public short[] additionalEffectLevel;
        [XmlAttribute] public string animationPrefix;
        [XmlAttribute] public string setEffect;
        [XmlAttribute] public string groundAttribute;

        [XmlAttribute] public int sgi_target;
        [XmlAttribute] public int sgi_boss_target;
    }
}

// ./data/xml/table/setiteminfo.xml
[XmlRoot("ms2")]
public partial class SetItemOptionRootKR {
    [XmlElement("set")] public List<SetItemOptionKR> option;
}

public partial class SetItemOptionKR : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int optionID;
    [M2dArray] public int[] itemIDs = [];

    [XmlElement("part")] public List<Part> part;

    public partial class Part : ItemOptionKR, IFeatureLocale {
        [XmlAttribute] public int count;
        [M2dArray] public int[] additionalEffectID;
        [M2dArray] public short[] additionalEffectLevel;
        [XmlAttribute] public string animationPrefix;
        [XmlAttribute] public string setEffect;
        [XmlAttribute] public string groundAttribute;

        [XmlAttribute] public int sgi_target;
        [XmlAttribute] public int sgi_boss_target;
    }
}
