using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/dungeonconfig.xml
[XmlRoot("ms2")]
public partial class DungeonConfigRoot {
    public List<DungeonConfig> dungeonConfig;
    public List<ReverseRaidConfig> reverseRaidConfig;
    public List<UnitedWeeklyReward> unitedWeeklyReward;
}

public partial class DungeonConfig {
    [XmlElement] public List<MissionRank> missionRank;
}

public partial class MissionRank {
    [XmlElement] public List<MissionRankGroup> groups;
}

public class MissionRankGroup {
    [XmlAttribute] public int id;
    [XmlAttribute] public string desc;
    [XmlAttribute] public int maxScore;
    [XmlElement] public List<MissionRankGroupEntry> entries;
}

public class MissionRankGroupEntry {
    [XmlAttribute] public int score;
}

public partial class ReverseRaidConfig {
    [XmlAttribute] public string startDate;
    [XmlAttribute] public int periodDays;
    [XmlElement] public List<ReverseRaidConfigEntry> entries;
}

public class ReverseRaidConfigEntry {
    [XmlAttribute] public int dungeonID;
}

public partial class UnitedWeeklyReward {
    [XmlAttribute] public int rewardCount;
    [XmlAttribute] public int rewardID;
}
