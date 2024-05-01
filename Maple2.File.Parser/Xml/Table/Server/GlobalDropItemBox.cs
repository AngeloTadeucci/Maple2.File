using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/globalDropItemBox_Final.xml
[XmlRoot("ms2")]
public partial class GlobalDropItemBoxRoot {
    [XmlElement] public List<GlobalDropItemBox> dropBox;
}

public partial class GlobalDropItemBox {
    [XmlAttribute] public int dropBoxID;
    [XmlAttribute] public string comment = string.Empty;
    [M2dFeatureLocale(Selector = "dropGroupIDs")] private IList<Item> _v;

    public partial class Item : IFeatureLocale {
        [XmlAttribute] public int dropGroupIDs;
        [M2dArray] public int[] dropCount = Array.Empty<int>();
        [XmlAttribute] public int minLevel;
        [XmlAttribute] public int maxLevel;
        [M2dArray] public int[] dropCountProbability = Array.Empty<int>();
        [XmlAttribute] public bool isOwnerDrop;
        [XmlAttribute] public int mapTypeCondition;
        [XmlAttribute] public int continentCondition;
        [XmlAttribute] public string reference1 = string.Empty;
    }
}
