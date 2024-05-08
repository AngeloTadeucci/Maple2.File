using System;
using System.Numerics;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.AI;

public class SummonNode : NodeEntry {
    public int npcId;
    public int npcCount;
    public int npcCountMax;
    public int delayTick;
    public int lifeTime;
    public Vector3 summonRot;
    public Vector3 summonPos;
    public Vector3 summonPosOffset;
    public Vector3 summonTargetOffset;
    public Vector3 summonRadius;
    public int group;
    public SummonMaster master;
    public SummonOption[] option = Array.Empty<SummonOption>();
    public long cooltime;
    public bool isKeepBattle;
}
