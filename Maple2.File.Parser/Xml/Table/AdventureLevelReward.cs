using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/adventurelevelreward.xml
[XmlRoot("ms2")]
public partial class AdventureLevelRewardRoot {
    [XmlElement] public List<AdventureLevelReward> reward;
}

public partial class AdventureLevelReward {
    [XmlAttribute] public int level;
    [XmlAttribute] public string type = string.Empty;
    [XmlAttribute] public int id;
    [XmlAttribute] public short rank;
    [XmlAttribute] public int value;
}
