using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/rewardcontentexpstatictable.xml
[XmlRoot("ms2")]
public class RewardContentExpStaticRoot {
    [XmlElement] public List<RewardContentExpStatic> table;
}

public class RewardContentExpStatic {
    [XmlAttribute] public int expTableID;
    [XmlElement] public List<RewardContentExpBase> @base;
}

public class RewardContentExpBase {
    [XmlAttribute] public long exp;
}
