using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/individualitemdrop.xml
// ./data/xml/table/individualitemdrop_charge.xml
// ./data/xml/table/individualitemdrop_event.xml
// ./data/xml/table/individualitemdrop_eventnpc.xml
// ./data/xml/table/individualitemdrop_newgacha.xml
// ./data/xml/table/individualitemdrop_pet.xml
// ./data/xml/table/individualitemdrop_quest_obj.xml
// ./data/xml/table/na/individualitemdrop_gacha.xml
// ./data/xml/table/na/individualitemdrop_gearbox.xml
[XmlRoot("ms2")]
public partial class IndividualItemDropRoot {
    [M2dFeatureLocale(Selector = "individualDropBoxID|dropGroup|item")] private IList<IndividualItemDrop> _individualDropBox;
}

public partial class IndividualItemDrop : IFeatureLocale {
    [XmlAttribute] public int individualDropBoxID;

    // CItemDropDataIndividual
    [XmlAttribute] public int item;
    [XmlAttribute] public int item2;

    [XmlAttribute] public int itemCode;
    [XmlAttribute] public int weight;
    [M2dNullable] public int? PackageUIShowGrade;
    [XmlAttribute] public bool assistBonus;
    [XmlAttribute] public bool constraintsQuest;
    [XmlAttribute] public int enchantLevel;
    [XmlAttribute] public short petLevel;
    [XmlAttribute] public int socketDataID;

    [XmlAttribute] public bool tradableCountDeduction;
    [XmlAttribute] public bool rePackingLimitCountDeduction;
    [XmlAttribute] public bool disableBreak;
    [XmlAttribute] public bool isBindCharacter;
    [XmlAttribute] public bool showIconOnGachaUI;

    [XmlAttribute] public int properJobWeight;
    [XmlAttribute] public int imProperJobWeight;
    [XmlAttribute] public bool isAnnounce;
    [XmlAttribute] public byte showTooltip;

    // CItemDropInitParam
    // if CItemDropDataIndividual.itemCode == 90000008, * 10000
    [XmlAttribute] public float minCount;
    [XmlAttribute] public float maxCount;

    [M2dArray] public int[] mapDependency = Array.Empty<int>();
    [M2dArray] public int[] grade = Array.Empty<int>();
    [M2dArray] public int[] gradeProbability = Array.Empty<int>();

    // After Init
    [XmlAttribute] public int smartDropRate;
    [XmlAttribute] public byte dropGroup;
    [XmlAttribute] public short dropGroupMinLevel;
    [XmlAttribute] public bool isSharedDrop;
    [XmlAttribute] public bool isApplySmartGenderDrop;
    [XmlAttribute] public bool serverDrop;
    [M2dArray] public int[] dropCount = Array.Empty<int>();
    [M2dArray] public int[] dropCountProbability = Array.Empty<int>();
}

// ./data/xml/table/individualitemdrop_final.xml
[XmlRoot("ms2")]
public partial class IndividualItemDropRootKR {
    [XmlElement("dropBox")] public List<IndividualItemDropBox> DropBoxes = [];
}

public partial class IndividualItemDropBox : IFeatureLocale {
    [XmlAttribute("dropBoxID")] public int DropBoxID;

    [XmlElement("group")] public List<IndividualItemDropGroup> Groups = [];
}

public partial class IndividualItemDropGroup : IFeatureLocale {
    [XmlAttribute("dropGroupID")] public int DropGroupID;

    [XmlElement("v")] public List<IndividualItemDropItem> Items = [];
}

public partial class IndividualItemDropItem : IFeatureLocale {
    [XmlAttribute] public int enchantLevel;
    [XmlAttribute] public int itemID;
    [XmlAttribute] public int itemID2;
    [XmlAttribute] public int itemLifeType;
    [XmlAttribute] public int itemLifeValue;
    [XmlAttribute] public float maxCount;
    [XmlAttribute] public float minCount;
    [XmlAttribute] public bool showIconOnGachaUI;
    [XmlAttribute] public byte showTooltip;
    [XmlAttribute] public int socketDataID;
    [XmlAttribute] public bool tradableCountDeduction;
    [XmlAttribute] public int uiItemRank;
}
