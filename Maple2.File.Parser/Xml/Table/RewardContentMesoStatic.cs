using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/rewardcontentmesostatictable.xml
[XmlRoot("ms2")]
public class RewardContentMesoStaticRoot {
    [XmlElement] public List<RewardContentMesoStatic> table;
}

public class RewardContentMesoStatic {
    [XmlAttribute] public int mesoTableID;
    [XmlElement] public List<RewardContentMesoStaticValue> v;
}

public class RewardContentMesoStaticValue {
    [XmlAttribute] public long meso;
}
