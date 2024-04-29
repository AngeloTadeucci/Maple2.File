using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/jobConditionTable.xml
[XmlRoot("ms2")]
public partial class JobConditionTableRoot {
    [XmlElement] public List<JobConditionTable> condition;
}

public partial class JobConditionTable {
    [XmlAttribute] public int npcID;
    [XmlAttribute] public int scriptID;
    [XmlAttribute] public int quest_start;
    [XmlAttribute] public int quest_complete;
    [XmlAttribute] public int item;
    [XmlAttribute] public int itemCount;
    [XmlAttribute] public short job;
    [XmlAttribute] public bool privilege;
    [XmlAttribute] public bool maid_auth;
    [XmlAttribute] public int maid_mood_time;
    [XmlAttribute] public int maid_affinity_time;
    [XmlAttribute] public int maid_affinity_grade;
    [XmlAttribute] public int maid_ready_to_pay;
    [XmlAttribute] public bool maid_day_before_expired;
    [XmlAttribute] public bool maid_expired;
    [XmlAttribute] public string date = string.Empty;
    [XmlAttribute] public int buff;
    [XmlAttribute] public int meso;
    [XmlAttribute] public short level;
    [XmlAttribute] public bool home;
    [XmlAttribute] public bool panelty;
    [XmlAttribute] public bool roulette;
    [XmlAttribute] public bool guild;
    [XmlAttribute] public int dropbox_get_item_id;
    [XmlAttribute] public short dropbox_get_item_rank;
    [XmlAttribute] public int map;
    [XmlAttribute] public int achieve_complete;
    [XmlAttribute] public bool birthday;
    [XmlAttribute] public short jobCode;
    [XmlAttribute] public int moveFieldID;
    [XmlAttribute] public int movePortalID;
}
