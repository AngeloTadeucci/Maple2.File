using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Numerics;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.AI;

public class Entry {
    public string name = string.Empty;
}

public class Comment : Entry {
    public string contents;
}

public class Node : Entry {

    public List<Entry> entries = new List<Entry>();
    public IList<Condition> conditions = new List<Condition>();

    public int limit;
    public int skillIdx;
    public string animation = string.Empty; // kfm anim name
    public int speed;
    public int till;
    public long initialCooltime;
    public long cooltime;
    public bool isKeepBattle;
    public int idx;
    public short level;
    public int[] prob = new int[] { 100 };
    public bool sequence;
    public Vector3 facePos; // clean out 0
    public int faceTargetTick;
    public Vector3 pos;
    public int faceTarget;
    public string key = string.Empty;
    public int value;
    public string type = string.Empty; // rand, near, far, remove, talk, cutin, mid, add, nearAssociated, hasAdditional, randAssociated, rankAssociate, slave, grabbedUser, random, 2
    public int rank;
    public int additionalId;
    public short additionalLevel;
    public int from;
    public int to;
    public Vector3 center; // clean out period commas
    public AiTarget target = AiTarget.defaultTarget; // hostile, friendly
    public bool noChangeWhenNoTarget;
    public string message = string.Empty;
    public int durationTick;
    public int delayTick;
    public bool isModify;
    public float heightMultiplier;
    public bool useNpcProb;
    public Vector3 destination;
    public int npcId;
    public int npcCountMax;
    public int npcCount;
    public int lifeTime; // sanitize a single float
    public Vector3 summonRot;
    public Vector3 summonPos; // sanitize double ,
    public Vector3 summonPosOffset;
    public Vector3 summonTargetOffset;
    public Vector3 summonRadius; // sanitize a float
    public int group;
    public SummonMaster master; // Slave, None
    public SummonOption[] option = Array.Empty<SummonOption>(); // masterHP,hitDamage
    public int triggerID;
    public bool isRideOff;
    public int[] rideNpcIDs = Array.Empty<int>();
    public bool isRandom;
    public float hpPercent;
    public int id;
    public bool isTarget;
    public string effectName = string.Empty; // xml effect
    public int groupID;
    public string illust = string.Empty; // side popup asset name
    public int duration;
    public string script = string.Empty;
    public string sound = string.Empty; // sound asset name
    public string voice = string.Empty; // voice asset path
    public int height;
    public int radius;
    public int timeTick;
    public bool isShowEffect;
    public string normal = string.Empty; // kfm anim name
    public string reactable = string.Empty; // kfm anim name
    public int interactID;
    public string kfmName = string.Empty;
    public int randomRoomID;
    public int portalDuration;

    /*
     * for searching the xmls
     * bool: "(?!([01]|true|false)")([^"]+")
     * byte: "(?!-?[0-9]{1,2}")([^"]+")
     * byte[]: "(?!-?[0-9]{1,2}(,[0-9]{1,2})*")([^"]+")
     * short: "(?!-?[0-9]{1,4}")([^"]+")
     * short[]: "(?!-?[0-9]{1,4}(,[0-9]{1,4})*")([^"]+")
     * int: "(?!-?[0-9]{1,9}")([^"]+")
     * int[]: "(?!-?[0-9]{1,9}(,[0-9]{1,9})*")([^"]+")
     * float: "(?!-?[0-9]+(\.[0-9]*)?")([^"]+")
     * vector3: "(?!-?[0-9]+(\.[0-9]*)?, *-?[0-9]+(\.[0-9]*)?, *-?[0-9]+(\.[0-9]*)? *")([^"]+")
     * vector3 typo: "(?!-?[0-9]+(\.[0-9]*)?[,.] *-?[0-9]+(\.[0-9]*)?[,.] *-?[0-9]+(\.[0-9]*)? *")([^"]+")
    */
}

public class AiPreset : Entry {
}
