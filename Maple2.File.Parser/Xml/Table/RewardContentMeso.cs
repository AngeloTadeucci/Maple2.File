using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/rewardcontentmesotable.xml
[XmlRoot("ms2")]
public class RewardContentMesoRoot {
    [XmlElement] public List<RewardContentMeso> table;
}

public class RewardContentMeso {
    [XmlAttribute] public int mesoTableID;
    [XmlElement] public List<RewardContentMesoValue> v;
}

public class RewardContentMesoValue {
    [XmlAttribute] public int level;
    [XmlAttribute] public long meso;
}
