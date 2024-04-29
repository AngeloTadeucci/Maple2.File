using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/scriptEventCondition.xml
[XmlRoot("ms2")]
public class ScriptEventConditionRoot {
    [XmlElement] public List<ScriptEventCondition> @event;
}

public partial class ScriptEventCondition {
    [XmlAttribute] public int id;
    [M2dEnum] public ScriptEventType type;
    [XmlAttribute] public int enchantError;
    [XmlAttribute] public int rank;
    [XmlAttribute] public string enchantLevel = string.Empty;
    [XmlAttribute] public int failCount;
    [XmlAttribute] public int isDamaged;
    [XmlAttribute] public int result;
    [XmlAttribute] public string desc = string.Empty;
}
