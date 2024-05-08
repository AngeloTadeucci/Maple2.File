using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.AI;

public class BuffNode : NodeEntry {
    public int id;
    public short level;
    public NodeBuffType type = NodeBuffType.add;
    public int prob = 100;
    public long initialCooltime;
    public long cooltime;
    public bool isTarget;
    public bool isKeepBattle;
}
