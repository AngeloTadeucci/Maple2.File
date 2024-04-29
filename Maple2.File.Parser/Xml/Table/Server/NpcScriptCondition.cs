using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/npcScriptCondition_Final.xml
[XmlRoot("ms2")]
public partial class NpcScriptConditionRoot {
    [M2dFeatureLocale(Selector = "npcID|scriptID")] private IList<NpcScriptCondition> _condition;
}

public partial class NpcScriptCondition : IFeatureLocale {
    [XmlAttribute] public int npcID;
    [XmlAttribute] public int scriptID;
    [XmlAttribute] public int maid_auth;
    [XmlAttribute] public bool maid_ready_to_pay;
    [XmlAttribute] public string maid_day_before_expired;
    [XmlAttribute] public string maid_expired;
    [XmlAttribute] public string maid_mood_time;
    [XmlAttribute] public string maid_affinity_time;
    [XmlAttribute] public int maid_affinity_grade;
    [XmlAttribute] public int privilege;
    [XmlAttribute] public int panelty;
    [M2dArray] public short[] job = Array.Empty<short>();
    [XmlAttribute] public string level;
    [M2dArray] public string[] quest_start = Array.Empty<string>();
    [M2dArray] public string[] quest_complete = Array.Empty<string>();
    [M2dArray] public string[] item = Array.Empty<string>();
    [M2dArray] public string[] itemCount = Array.Empty<string>();
    [XmlAttribute] public int weddingState;
    [XmlAttribute] public int weddingHallBooking;
    [XmlAttribute] public int marriageDate;
    [XmlAttribute] public string weddingHallEntryType;
    [XmlAttribute] public string weddingHallState;
    [XmlAttribute] public string coolingOff;
    [XmlAttribute] public string buff;
    [XmlAttribute] public string achieve_complete;
    [XmlAttribute] public int meso;
    [XmlAttribute] public bool guild;
}
