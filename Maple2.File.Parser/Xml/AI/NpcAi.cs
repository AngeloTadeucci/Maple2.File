using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AI;

// ./data/server/ai/**/%s.xml
[XmlRoot("npcAi")]
public class NpcAi {
    [XmlElement] public AiReservedNode reserved;
    [XmlElement] public AiBattleNode battle;
    [XmlElement] public AiBattleEndNode battleEnd;
    [XmlElement] public AiPresetsNode aiPresets;
}

public partial class AiReservedNode {
    [M2dFeatureLocale] private IList<Condition> _condition;
}

public class AiBattleNode {
    [XmlElement] public List<Node> node;
}

public class AiBattleEndNode {
    [XmlElement] public List<Node> node;
}

public class AiPresetsNode {
    [XmlElement] public List<AiPreset> aiPreset;
}