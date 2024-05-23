using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/dungeonconfig.xml
[XmlRoot("ms2")]
public class DungeonConfigRoot {
    [XmlElement] public List<DungeonConfig> DungeonConfig;
    [XmlElement] public List<ReverseRaidConfig> ReverseRaidConfig;
    [XmlElement] public List<UnitedWeeklyReward> UnitedWeeklyReward;
}

public class DungeonConfig {
    [XmlElement] public List<MissionRank> MissionRank;
}

public class MissionRank {
    [XmlElement] public List<MissionRankGroup> group;
}

public class MissionRankGroup {
    [XmlAttribute] public int id;
    [XmlAttribute] public string desc = string.Empty;
    [XmlAttribute] public int maxScore;
    [XmlElement] public List<MissionRankGroupEntry> rank;
}

public class MissionRankGroupEntry {
    [XmlAttribute] public int score;
}

public class ReverseRaidConfig {
    [XmlAttribute] public string startDate = string.Empty;
    [XmlAttribute] public int periodDays;
    [XmlElement] public List<ReverseRaidConfigEntry> v;
}

public class ReverseRaidConfigEntry {
    [XmlAttribute] public int dungeonID;
}

public class UnitedWeeklyReward {
    [XmlElement] public List<UnitedWeeklyRewardEntry> v;
}

public class UnitedWeeklyRewardEntry {
    [XmlAttribute] public int rewardCount;
    [XmlAttribute] public int rewardID;
    [XmlAttribute] public int uiPosX;
    [XmlAttribute] public bool uiShowBg;
}
