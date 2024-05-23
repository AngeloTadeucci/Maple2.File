using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/adventurelevelmission.xml
[XmlRoot("ms2")]
public partial class AdventureLevelMissionRoot {
    [XmlElement] public List<AdventureLevelMission> mission;
}

public partial class AdventureLevelMission {
    [XmlAttribute] public int missionId;
    [XmlAttribute] public string missionNameKey = string.Empty;
    [XmlAttribute] public int missionCount;
    [XmlAttribute] public int itemId;
    [XmlAttribute] public short itemRank;
    [XmlAttribute] public int itemCount;
}
