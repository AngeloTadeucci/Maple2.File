using System.Collections.Generic;

namespace Maple2.File.Parser.Xml.AI;

public abstract class Entry {
    public string name;

    public List<Entry> Entries;
}

public class Comment : Entry {
    public string Value;
}

public abstract class NodeEntry : Entry { }

public abstract class ConditionEntry : Entry { }

public class AiPresetEntry : Entry { }
