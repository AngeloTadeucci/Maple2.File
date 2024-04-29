using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/QuestScriptCondition_Final.xml
[XmlRoot("ms2")]
public partial class QuestScriptConditionRoot {
    [M2dFeatureLocale(Selector = "questID|scriptID")] private IList<QuestScriptCondition> _condition;
}

public partial class QuestScriptCondition : IFeatureLocale {
    [XmlAttribute] public int questID;
    [XmlAttribute] public int scriptID;
    [XmlAttribute] public bool maid_auth;
    [XmlAttribute] public string maid_ready_to_pay = string.Empty;
    [XmlAttribute] public string maid_day_before_expired = string.Empty;
    [XmlAttribute] public string maid_expired = string.Empty;
    [XmlAttribute] public string maid_mood_time = string.Empty;
    [XmlAttribute] public string maid_affinity_time = string.Empty;
    [XmlAttribute] public int maid_affinity_grade = 0;
    [XmlAttribute] public int privilege;
    [XmlAttribute] public int panelty;
    [M2dArray] public short[] job = Array.Empty<short>();
    [XmlAttribute] public string level = string.Empty;
    [M2dArray] public string[] quest_start = Array.Empty<string>();
    [M2dArray] public string[] quest_complete = Array.Empty<string>();
    [M2dArray] public string[] item = Array.Empty<string>();
    [M2dArray] public string[] itemCount = Array.Empty<string>();
    [XmlAttribute] public int weddingState;
    [XmlAttribute] public int weddingHallBooking;
    [XmlAttribute] public int marriageDate;
    [XmlAttribute] public string weddingHallEntryType = string.Empty;
    [XmlAttribute] public string weddingHallState = string.Empty;
    [XmlAttribute] public string coolingOff = string.Empty;
    [XmlAttribute] public string buff = string.Empty;
    [XmlAttribute] public string achieve_complete = string.Empty;
    [XmlAttribute] public string meso = string.Empty;
    [XmlAttribute] public bool guild;
}
