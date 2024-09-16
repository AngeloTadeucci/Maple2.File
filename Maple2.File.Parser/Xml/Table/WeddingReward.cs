using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/weddingreward.xml
[XmlRoot("ms2")]
public class WeddingRewardRoot {
    [XmlElement] public List<WeddingReward> v;
}

public partial class WeddingReward {
    [M2dEnum] public WeddingRewardType type;
    [XmlAttribute] public int rewardExp;
    [M2dEnum] public WeddingRewardLimit rewardLimit;
}
