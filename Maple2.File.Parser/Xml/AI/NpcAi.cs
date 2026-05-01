namespace Maple2.File.Parser.Xml.AI;

// ./data/server/ai/**/%s.xml
public class NpcAi {
    public List<Entry> Reserved = new();
    public Battle Battle = new();
    public BattleEnd BattleEnd = new();
    public List<Entry> AiPresets = new();
}

public class Battle {
    public string startAni = string.Empty;
    public string endAni = string.Empty;
    public bool isBattle;
    public List<Entry> Entries = [];
}

public class BattleEnd {
    public bool onlyDead;
    public List<Entry> Entries = [];
}
