using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/timeEventData.xml
[XmlRoot("ms2")]
public partial class TimeEventDataRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<TimeEventData> _event;
}

public partial class TimeEventData : IFeatureLocale {
    [XmlAttribute] public int id;
    [M2dEnum] public TimedEventType type = TimedEventType.Boss;
    [XmlAttribute] public int prob;
    [XmlAttribute] public string startTime = "2014-1-1-00-05-00";
    [XmlAttribute] public string endTime = "2099-12-31-12-00-00";
    [XmlAttribute] public string cycleTime = string.Empty;
    [XmlAttribute] public string randomTime = string.Empty;
    [XmlAttribute] public string lifeTime = string.Empty;
    [XmlAttribute] public bool individualChannelSpawn;
    [XmlAttribute] public bool screenNotice;
    [XmlAttribute] public bool chatNotice;
    [XmlAttribute] public float variableCountByChannelCount;
    [M2dArray] public int[] targetFields = Array.Empty<int>();
    [XmlAttribute] public bool noticeMap;
    [M2dArray] public int[] targetSpawnPointIDs = Array.Empty<int>();
    [XmlAttribute] public int tag;
    [M2dArray] public string[] targetSpawnTags = Array.Empty<string>();
    [M2dArray] public int[] npcIDs = Array.Empty<int>();
    [XmlAttribute] public bool lifeTimeText1;
    [XmlAttribute] public bool unique;
    [XmlAttribute] public int roomID;
    [XmlAttribute] public int roomCount;
    [XmlAttribute] public int interactCount;
    [XmlAttribute] public int interactID;
    [XmlAttribute] public bool keepAnimate;
    [XmlAttribute] public string interactModel = string.Empty;
    [XmlAttribute] public string interactAsset = string.Empty;
    [XmlAttribute] public string interactNormal = string.Empty;
    [XmlAttribute] public string interactReactable = string.Empty;
    [XmlAttribute] public string popupMessage = string.Empty;
    [XmlAttribute] public string soundID = string.Empty;
    [XmlAttribute] public string eventName1 = string.Empty;
    [XmlAttribute] public string eventName2 = string.Empty;
    [XmlAttribute] public string eventName3 = string.Empty;
    [M2dArray] public int[] eventField1 = Array.Empty<int>();
    [M2dArray] public int[] eventField2 = Array.Empty<int>();
    [M2dArray] public int[] eventField3 = Array.Empty<int>();
    [XmlAttribute] public int triggerID;
    [XmlAttribute] public string key = string.Empty;
    [XmlAttribute] public int value;
    [XmlAttribute] public int fieldWarGroupID;
    [XmlAttribute] public int eventDurationStartHour;
    [XmlAttribute] public int eventDurationEndHour;
    [XmlAttribute] public int eventDurationStartMin;
    [XmlAttribute] public int eventDurationEndMin;
}
