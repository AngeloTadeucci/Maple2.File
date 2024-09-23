using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/itemOptionRandom.xml
[XmlRoot("ms2")]
public class ItemOptionRandomRoot {
    [XmlElement] public List<ItemOptionRandom> option;
}

public class ItemOptionRandom {
    [XmlAttribute] public int code;
    [XmlAttribute] public int statGroup;
    [XmlAttribute] public int levelGroupID;
    [XmlAttribute] public int pickCount;
    [XmlAttribute] public bool isRarePickOne;
    [XmlAttribute] public int copyID;
    [XmlElement] public List<ItemOptionStat> v;

    public class ItemOptionStat {
        [XmlAttribute] public string name = string.Empty;
        [XmlAttribute] public int weight = 1;
        [XmlAttribute] public int statID;
    }
}
