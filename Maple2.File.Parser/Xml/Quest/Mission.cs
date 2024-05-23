using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Quest;

public class EventMission {
    [XmlAttribute("event")] public string @event = string.Empty; // EventMission
}

public class MentoringMission {
    [XmlAttribute] public string mentoringIcon = string.Empty;
    [XmlAttribute] public int openingDay = 1;
    [XmlAttribute] public int mentoringSeason;
}
