using System.Collections.Generic;

namespace Maple2.File.Parser.Xml.AI;

// ./data/server/ai/**/%s.xml
public class NpcAi {
    public List<Entry> Reserved = new();
    public List<Entry> Battle = new();
    public List<Entry> BattleEnd = new();
    public List<Entry> AiPresets = new();
}
