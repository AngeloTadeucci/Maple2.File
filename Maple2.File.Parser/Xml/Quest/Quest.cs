using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Quest;

// ./data/xml/quest/%08d.xml
[XmlRoot("ms2")]
public partial class QuestDataRootRoot {
    [M2dFeatureLocale] private QuestDataRoot _environment;
}

public partial class QuestDataRoot : IFeatureLocale {
    [XmlElement] public QuestData quest;
}

public partial class QuestData {
    [XmlElement] public Basic basic;
    [XmlElement] public Notify notify;
    [XmlElement] public Require require;

    [XmlElement] public List<Condition> condition;

    //[XmlElement] public Navigation navi;
    [XmlElement] public Start start;
    [XmlElement] public Complete complete;
    [XmlElement] public Reward completeReward;
    [XmlElement] public Reward acceptReward;
    [XmlElement] public ProgressMap progressMap;
    [XmlElement] public Guide guide;
    [XmlElement] public EventMission eventMission;
    [XmlElement] public MentoringMission mentoringMission; // feature="Mentoring"
    [XmlElement] public Dispatch dispatch;
    [XmlElement] public GotoNpc gotoNpc;
    [XmlElement] public GotoDungeon gotoDungeon;
    [XmlElement] public Remote remoteAccept;
    [XmlElement] public Remote remoteComplete;
    [XmlElement] public SummonPortal summonPortal;

    public class Start {
        [XmlAttribute] public int npc;
    }

    public partial class Complete {
        [XmlAttribute] public int npc;
        [M2dEnum] public NavigationType type = NavigationType.unknown;

        //[M2dArray] public int[] code = Array.Empty<int>(); // Never set
        [M2dArray] public int[] map = Array.Empty<int>();

        // Ignored by client.
        [XmlAttribute] public int fieldID;
    }
}


[XmlRoot("ms2")]
public partial class QuestDataRootKR {
    [XmlElement("quest")] public List<QuestDataKR> quests;
}

public partial class QuestDataKR : QuestData, IFeatureLocale {
    [XmlAttribute] public int id;
}
