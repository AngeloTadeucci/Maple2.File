using System.Numerics;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.AI;

public class TargetNode : NodeEntry {
    public NodeTargetType type = NodeTargetType.rand;
    public int prob = 100;
    public int rank;
    public int additionalId;
    public short additionalLevel;
    public int from;
    public int to;
    public Vector3 center;
    public AiTarget target = AiTarget.defaultTarget;
    public bool noChangeWhenNoTarget;
    public long initialCooltime;
    public long cooltime;
    public bool isKeepBattle;
}
