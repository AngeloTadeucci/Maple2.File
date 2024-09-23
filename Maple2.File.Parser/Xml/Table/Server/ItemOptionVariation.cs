using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/itemOptionVariation.xml
[XmlRoot("ms2")]
public class ItemOptionVariationRoot {
    [XmlElement] public List<ItemOptionVariation> option;
}

public class ItemOptionVariation {
    [XmlAttribute] public int id;
    [XmlAttribute] public int multipleID;
    [XmlAttribute] public int groupType;
    [XmlAttribute] public string name = string.Empty;
    [XmlAttribute] public int levelGroupID;
    [XmlAttribute] public int highStat;
    [XmlAttribute] public int isRateType;
    [XmlElement] public List<ItemOptionStat> v;

    public class ItemOptionStat {
        [XmlAttribute] public int stat;
        [XmlAttribute] public int weight = 1;
    }
}
