using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AI;

// ./data/server/ai/**/%s.xml
public class NpcAi {
    public AiReservedNode reserved = new AiReservedNode();
    public AiBattleNode battle = new AiBattleNode();
    public AiBattleEndNode battleEnd = new AiBattleEndNode();
    public AiPresetsNode aiPresets = new AiPresetsNode();
}

public class AiReservedNode {
    public IList<Condition> conditions;
}

public class AiBattleNode {
    public List<Node> nodes;
}

public class AiBattleEndNode {
    public List<Node> nodes;
}

public class AiPresetsNode {
    public List<AiPresetDefinition> aiPresets;
}