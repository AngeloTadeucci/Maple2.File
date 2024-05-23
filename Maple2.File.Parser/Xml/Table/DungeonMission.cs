using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/dungeonmission.xml
[XmlRoot("ms2")]
public partial class DungeonMissionRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<DungeonMission> _dungeonMission;
}

public partial class DungeonMission : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public string type;
    [M2dArray] public int[] value1 = Array.Empty<int>();
    [XmlAttribute] public int value2 = 0;
    [XmlAttribute] public int maxScore;
    [XmlAttribute] public int applyCount;
    [XmlAttribute] public bool isPenaltyType;
}
