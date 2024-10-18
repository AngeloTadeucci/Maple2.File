using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Quest;

public partial class Basic {
    [XmlAttribute] public int chapterID;
    [XmlAttribute] public int questID;
    [XmlAttribute] public int standardLevel;
    [XmlAttribute] public bool autoStart;
    [XmlAttribute] public bool disableGiveup;
    [XmlAttribute] public bool exceptChapterClear;
    [XmlAttribute] public int repeatable; // 0,1,2,3
    [XmlAttribute] public int questType; // 0,1,2,3,4,5,6,8,9
    [XmlAttribute] public int account; // 0,1,2
    [XmlAttribute] public string eventTag = string.Empty;
    [XmlAttribute] public bool locking;
    [XmlAttribute] public int tabIndex = -1; // -1,1,2
    [XmlAttribute] public bool forceRegistGuide;
    [XmlAttribute] public bool useNavi;
    [M2dEnum] public AllianceType alliance = AllianceType.unknown;
    [M2dEnum] public AllianceRank rank = AllianceRank.Unknown;
    [XmlAttribute] public bool usePostbox;
    [XmlAttribute] public bool useReEntryHiddenMap;
    [XmlAttribute] public string usePeriod = string.Empty;
    [M2dArray] public QuestPropertyType[] property;
}
