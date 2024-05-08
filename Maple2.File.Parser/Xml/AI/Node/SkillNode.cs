using System.Numerics;

namespace Maple2.File.Parser.Xml.AI;

public class SkillNode : NodeEntry {
    public int idx;
    public short level;
    public int prob = 100;
    public bool sequence;
    public Vector3 facePos;
    public int faceTarget;
    public int faceTargetTick;
    public long initialCooltime;
    public long cooltime;
    public int limit;
    public bool isKeepBattle;
}
