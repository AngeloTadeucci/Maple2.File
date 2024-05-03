using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/globalDropItemSet_Final.xml
[XmlRoot("ms2")]
public partial class GlobalDropItemSetRoot {
    [XmlElement] public List<GlobalDropItemSet> dropBox;
}

public partial class GlobalDropItemSet {
    [XmlAttribute] public int dropGroupID;
    [XmlAttribute] public string comment = string.Empty;
    [M2dFeatureLocale] private IList<Item> _v;

    public partial class Item : IFeatureLocale {
        [XmlAttribute] public int itemID;
        [XmlAttribute] public int minLevel;
        [XmlAttribute] public int maxLevel;
        [XmlAttribute] public int minCount;
        [XmlAttribute] public int maxCount;
        [XmlAttribute] public short uiItemRank;
        [XmlAttribute] public short grade;
        [XmlAttribute] public int weight;
        [M2dArray] public int[] mapDependency = Array.Empty<int>();
        [XmlAttribute] public bool constraintsQuest;
    }
}
