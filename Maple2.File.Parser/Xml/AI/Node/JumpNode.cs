using System.Numerics;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.AI;

public class JumpNode : NodeEntry {
    public Vector3 pos;
    public int speed;
    public float heightMultiplier;
    public NodeJumpType type = NodeJumpType.jumpA;
    public long cooltime;
    public bool isKeepBattle;
}
