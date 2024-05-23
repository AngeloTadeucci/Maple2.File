using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/dungeonrankreward.xml
[XmlRoot("ms2")]
public partial class DungeonRankRewardRoot {
    [M2dFeatureLocale(Selector = "rewardID")] private IList<DungeonRankReward> _DungeonRankReward;
}

public partial class DungeonRankReward : IFeatureLocale {
    [XmlAttribute] public int rewardID;
    [XmlElement] public List<DungeonRankRewardEntry> v;
}

public class DungeonRankRewardEntry {
    [XmlAttribute] public int rank;
    [XmlAttribute] public int itemID;
    [XmlAttribute] public int systemMailID;
}
