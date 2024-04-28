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
    [XmlAttribute] public string maid_ready_to_pay;
    [XmlAttribute] public string maid_day_before_expired;
    [XmlAttribute] public string maid_expired;
    [XmlAttribute] public string maid_mood_time;
    [XmlAttribute] public string maid_affinity_time;
    [XmlAttribute] public int maid_affinity_grade;
    [XmlAttribute] public int privilege;
    [XmlAttribute] public int panelty;
    [M2dArray] public short[] job;
    [XmlAttribute] public string level;
    [M2dArray] public string[] quest_start;
    [M2dArray] public string[] quest_complete;
    [M2dArray] public string[] item;
    [M2dArray] public string[] itemCount;
    [XmlAttribute] public int weddingState;
    [XmlAttribute] public int weddingHallBooking;
    [XmlAttribute] public string weddingHallEntryType;
    [XmlAttribute] public string weddingHallState;
    [XmlAttribute] public string coolingOff;
    [XmlAttribute] public string buff;
    [XmlAttribute] public string achieve_complete;
}
