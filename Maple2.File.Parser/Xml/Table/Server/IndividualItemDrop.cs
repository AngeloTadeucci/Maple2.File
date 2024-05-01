using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/individualItemDrop_Final.xml
[XmlRoot("ms2")]
public partial class IndividualItemDropRoot {
    [XmlElement] public List<IndividualItemDrop> dropBox;
}

public partial class IndividualItemDrop {
    [XmlAttribute] public int dropGroupID;
    [XmlAttribute] public string comment = string.Empty;
    [M2dFeatureLocale(Selector = "dropGroupID")] private IList<Group> _group;

    public partial class Group : IFeatureLocale {
        [XmlAttribute] public int dropGroupID;
        [XmlAttribute] public int smartDropRate;
        [XmlAttribute] public int dropGroupMinLevel;
        [M2dArray] public int[] dropCount = Array.Empty<int>();
        [M2dArray] public int[] dropCountProbability = Array.Empty<int>();
        [XmlAttribute] public bool serverDrop;
        [XmlAttribute] public bool isApplySmartGenderDrop;
        [M2dFeatureLocale(Selector = "itemID")] private IList<Item> _v;

        public partial class Item : IFeatureLocale {
            [XmlAttribute] public int itemID;
            [XmlAttribute] public int itemID2;
            [XmlAttribute] public bool isAnnounce;
            [XmlAttribute] public int properJobWeight;
            [XmlAttribute] public int imProperJobWeight;
            [XmlAttribute] public int weight;
            [XmlAttribute] public int minCount;
            [XmlAttribute] public int maxCount;
            [XmlAttribute] public short uiItemRank;
            [M2dArray] public int[] gradeProbability = Array.Empty<int>();
            [M2dArray] public short[] grade = Array.Empty<short>();
            [XmlAttribute] public int enchantLevel;
            [XmlAttribute] public int socketDataID;
            [XmlAttribute] public bool tradableCountDeduction;
            [XmlAttribute] public byte showTooltip;
            [XmlAttribute] public string reference1 = string.Empty;
            [XmlAttribute] public bool disableBreak;
            [XmlAttribute] public bool showIconOnGachaUI;
            [M2dArray] public int[] mapDependency = Array.Empty<int>();
            [XmlAttribute] public bool constraintsQuest;
        }
    }
}
