using System.Numerics;

namespace Maple2.File.Parser.Xml.AI;

public class TeleportNode : NodeEntry {
    public Vector3 pos;
    public int prob = 100;
    public Vector3 facePos;
    public int faceTarget;
    public long initialCooltime;
    public long cooltime;
    public bool isKeepBattle;
}
