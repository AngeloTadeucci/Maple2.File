using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AI;

[XmlRoot("npcAi")]
public class NpcAi {
    [XmlElement] public Reserved reserved;
    [XmlElement] public Battle battle;
    [XmlElement] public BattleEnd battleEnd;
    [XmlElement] public AiPresets aiPresets;
}

public class Reserved {
    [XmlElement] public List<Condition> condition = new List<Condition>();
}
public class Battle {
    [XmlElement] public List<Node> node = new List<Node>();
}

public class BattleEnd {
    [XmlElement] public List<Node> node = new List<Node>() ;
}

public class AiPresets {
    [XmlElement] public List<AiPreset> aiPreset = new List<AiPreset>();
}