using System.Numerics;

namespace Maple2.File.Parser.Xml.AI;

public class RunawayNode : NodeEntry {
    public string animation = string.Empty;
    public int skillIdx;
    public int till;
    public int limit;
    public Vector3 facePos;
    public long initialCooltime;
    public long cooltime;
    public bool isKeepBattle;
}
