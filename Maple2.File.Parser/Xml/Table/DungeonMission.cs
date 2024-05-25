﻿using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/dungeonmission.xml
[XmlRoot("ms2")]
public partial class DungeonMissionRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<DungeonMission> _DungeonMission;
}

public partial class DungeonMission : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public string type = string.Empty;
    [M2dArray] public float[] value1 = Array.Empty<float>();
    [XmlAttribute] public int value2 = 0;
    [XmlAttribute] public int maxScore;
    [XmlAttribute] public int applyCount;
    [XmlAttribute] public bool isPenaltyType;
}
