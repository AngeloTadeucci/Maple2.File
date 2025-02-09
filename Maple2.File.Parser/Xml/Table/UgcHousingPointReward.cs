using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/ugchousingpointreward.xml
[XmlRoot("ms2")]
public partial class UgcHousingPointRewardRoot {
    [XmlElement("v")] public List<UgcHousingPointReward> Entries;
}

public partial class UgcHousingPointReward {
    [XmlAttribute] public int housingPoint;
    [XmlAttribute] public int individualDropBoxId;
    [XmlAttribute] public string icon;
    [XmlAttribute] public string stringKey;
}
