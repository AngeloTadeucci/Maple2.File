using System.Numerics;

namespace Maple2.File.Parser.Xml.AI;

public class MoveNode : NodeEntry {
    public Vector3 destination;
    public int prob = 100;
    public string animation = string.Empty;
    public int limit;
    public int speed;
    public int faceTarget;
    public long initialCooltime;
    public long cooltime;
    public bool isKeepBattle;
}
