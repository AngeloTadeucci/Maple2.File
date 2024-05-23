using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/mastery.xml
[XmlRoot("ms2")]
public partial class MasteryRewardRoot {
    [M2dFeatureLocale(Selector = "type")] private IList<MasteryReward> _mastery;
}

public partial class MasteryReward : IFeatureLocale {
    [M2dEnum] public MasteryType type;
    [XmlElement] public List<MasteryLevel> v;
}

public partial class MasteryLevel {
    [XmlAttribute] public int grade;
    [XmlAttribute] public int value;
    [XmlAttribute] public int rewardJobItemID;
    [XmlAttribute] public short rewardJobItemRank;
    [XmlAttribute] public int rewardJobItemCount;

}
