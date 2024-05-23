using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/survivallevelreward.xml
[XmlRoot("ms2")]
public partial class SurvivalLevelRewardRoot {
    [M2dFeatureLocale(Selector = "level")] private IList<SurvivalLevelReward> _survivalLevelReward;
}

//<survivalLevelReward level="1" rewardItemID1="" rewardItemRank1="" rewardItemCount1="" rewardItemID2="" rewardItemRank2="" rewardItemCount2="" rewardItemID3="" rewardItemRank3="" rewardItemCount3="" feature="SurvivalContents02" />
//<survivalLevelReward level="300" rewardItemID1="20301724" rewardItemRank1="1" rewardItemCount1="10" rewardItemID2="" rewardItemRank2="" rewardItemCount2="" rewardItemID3="" rewardItemRank3="" rewardItemCount3="" feature="SurvivalContents02" />
public partial class SurvivalLevelReward : IFeatureLocale {
    [XmlAttribute] public int level;
    [XmlAttribute] public int rewardItemID1;
    [XmlAttribute] public short rewardItemRank1;
    [XmlAttribute] public int rewardItemCount1;
    [XmlAttribute] public int rewardItemID2;
    [XmlAttribute] public short rewardItemRank2;
    [XmlAttribute] public int rewardItemCount2;
    [XmlAttribute] public int rewardItemID3;
    [XmlAttribute] public short rewardItemRank3;
    [XmlAttribute] public int rewardItemCount3;
}
