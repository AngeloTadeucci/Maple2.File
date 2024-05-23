using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/rewardcontentitemtable.xml
[XmlRoot("ms2")]
public class RewardContentItemRoot {
    [XmlElement] public List<RewardContentItem> table;
}

public class RewardContentItem {
    [XmlAttribute] public int itemTableID;
    [XmlElement] public List<RewardContentValue> v;
}

public class RewardContentValue {
    [XmlAttribute] public int minLevel;
    [XmlAttribute] public int maxLevel;

    [XmlElement] public List<RewardContentItemEntry> item;
}

public class RewardContentItemEntry {
    [XmlAttribute] public int itemID;
    [XmlAttribute] public int count;
    [XmlAttribute] public int grade;
}
