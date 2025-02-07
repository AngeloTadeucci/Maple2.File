using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/masteryugchousing.xml
[XmlRoot("ms2")]
public partial class MasteryUgcHousingRoot {
    [XmlElement("masteryUGCHousing")] public MasteryUgcHousingList MasteryUgcHousing;
}

public partial class MasteryUgcHousingList {
    [XmlElement("v")] public List<MasteryUgcHousing> Entries;
}

public partial class MasteryUgcHousing {
    [XmlAttribute] public int grade;
    [XmlAttribute] public int value;
    [XmlAttribute] public int rewardJobItemID;
    [XmlAttribute] public int rewardJobItemRank;
    [XmlAttribute] public int rewardJobItemCount;
}
