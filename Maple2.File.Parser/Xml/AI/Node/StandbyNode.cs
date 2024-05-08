using System.Numerics;

namespace Maple2.File.Parser.Xml.AI;

public class StandbyNode : NodeEntry {
    public int limit;
    public int prob = 100;
    public string animation = string.Empty;
    public Vector3 facePos;
    public int faceTarget;
    public long initialCooltime;
    public long cooltime;
    public bool isKeepBattle;
}
