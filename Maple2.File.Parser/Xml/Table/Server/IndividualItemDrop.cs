using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/individualItemDrop_Final.xml
[XmlRoot("ms2")]
public partial class IndividualItemDropRoot {
    [XmlElement] public List<IndividualItemDrop> dropBox;
}

public partial class IndividualItemDrop {
    [XmlAttribute] public int dropBoxID;
    [XmlAttribute] public string comment = string.Empty;
    [M2dFeatureLocale(Selector = "dropGroupID")] private IList<Group> _group;

    public bool ShouldSerializecomment() => comment != string.Empty;

    public partial class Group : IFeatureLocale {
        [XmlAttribute] public int dropGroupID;
        [XmlAttribute] public int smartDropRate;
        [XmlAttribute] public int dropGroupMinLevel;
        [XmlAttribute][M2dArray] public int[] dropCount = Array.Empty<int>();
        [XmlAttribute][M2dArray] public int[] dropCountProbability = Array.Empty<int>();
        [XmlAttribute] public bool serverDrop;
        [XmlAttribute] public bool isApplySmartGenderDrop;
        [M2dFeatureLocale(Selector = "itemID")] private IList<Item> _v;

        public bool ShouldSerializesmartDropRate() => smartDropRate != 0;

        public bool ShouldSerializedropGroupMinLevel() => dropGroupMinLevel != 0;

        public bool ShouldSerializedropCount() => dropCount.Length != 0;

        public bool ShouldSerializedropCountProbability() => dropCountProbability.Length != 0;

        public bool ShouldSerializeserverDrop() => serverDrop != false;

        public bool ShouldSerializeisApplySmartGenderDrop() => isApplySmartGenderDrop != false;

        public bool ShouldSerializeLocale() => Locale != null && Locale.Length > 0;

        public bool ShouldSerializeFeature() => Feature != null && Feature.Length > 0;

        public partial class Item : IFeatureLocale {
            [XmlAttribute] public int itemID;
            [XmlAttribute] public int itemID2;
            [XmlAttribute] public bool isAnnounce;
            [XmlAttribute] public int minCount;
            [XmlAttribute] public int maxCount;
            [XmlAttribute] public short uiItemRank;
            [XmlAttribute] public int weight;
            [XmlAttribute] public bool assistBonus;
            [XmlAttribute][M2dArray] public int[] gradeProbability = Array.Empty<int>();
            [XmlAttribute][M2dArray] public short[] grade = Array.Empty<short>();
            [XmlAttribute] public bool tradableCountDeduction;
            [XmlAttribute] public int properJobWeight;
            [XmlAttribute] public int imProperJobWeight;
            [XmlAttribute] public int enchantLevel;
            [XmlAttribute] public int socketDataID;
            [XmlAttribute] public bool isBindCharacter;
            [XmlAttribute] public bool rePackingLimitCountDeduction;
            [XmlAttribute] public byte showTooltip;
            [XmlAttribute] public string reference1 = string.Empty;
            [XmlAttribute] public bool disableBreak;
            [XmlAttribute] public bool showIconOnGachaUI;
            [XmlAttribute][M2dArray] public int[] mapDependency = Array.Empty<int>();
            [XmlAttribute] public bool constraintsQuest;

            public bool ShouldSerializeitemID2() => itemID2 != 0;

            public bool ShouldSerializeisAnnounce() => isAnnounce != false;

            public bool ShouldSerializeproperJobWeight() => properJobWeight != 0;

            public bool ShouldSerializeimProperJobWeight() => imProperJobWeight != 0;

            public bool ShouldSerializeweight() => weight != 0;

            public bool ShouldSerializeminCount() => minCount != 0;

            public bool ShouldSerializemaxCount() => maxCount != 0;

            public bool ShouldSerializeassistBonus() => assistBonus != false;

            public bool ShouldSerializeuiItemRank() => uiItemRank != 0;

            public bool ShouldSerializegradeProbability() => gradeProbability != null && gradeProbability.Length > 0;

            public bool ShouldSerializegrade() => grade != null && grade.Length > 0;

            public bool ShouldSerializeenchantLevel() => enchantLevel != 0;

            public bool ShouldSerializesocketDataID() => socketDataID != 0;

            public bool ShouldSerializetradableCountDeduction() => tradableCountDeduction != false;

            public bool ShouldSerializerePackingLimitCountDeduction() => rePackingLimitCountDeduction != false;

            public bool ShouldSerializeisBindCharacter() => isBindCharacter != false;

            public bool ShouldSerializeshowTooltip() => showTooltip != 0;

            public bool ShouldSerializereference1() => reference1 != string.Empty;

            public bool ShouldSerializedisableBreak() => disableBreak != false;

            public bool ShouldSerializeshowIconOnGachaUI() => showIconOnGachaUI != false;

            public bool ShouldSerializemapDependency() => mapDependency != null && mapDependency.Length > 0;

            public bool ShouldSerializeconstraintsQuest() => constraintsQuest != false;

            public bool ShouldSerializeLocale() => Locale != null && Locale.Length > 0;

            public bool ShouldSerializeFeature() => Feature != null && Feature.Length > 0;
        }
    }
}
