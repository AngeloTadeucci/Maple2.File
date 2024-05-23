using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/dungeonrounddata.xml
[XmlRoot("ms2")]
public partial class DungeonRoundDataRoot {
    public List<DungeonRoundGroup> dungeonRoundGroup;
}

public partial class DungeonRoundGroup {
    [XmlAttribute] public int id;
    [XmlElement] public List<DungeonRoundGroupEntry> entries;
}

public class DungeonRoundGroupEntry {
    [XmlAttribute] public int rewardID;
    [XmlAttribute] public int gearScore;
}
