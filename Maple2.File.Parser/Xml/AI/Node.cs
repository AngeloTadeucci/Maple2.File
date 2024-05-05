using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Numerics;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.AI;


public partial class Node {
    [XmlAttribute] public string name = string.Empty;

    [XmlElement] public List<Node> node;
    [M2dFeatureLocale] private IList<Condition> _condition;
    [XmlElement] public List<AiPreset> aiPreset;

    [XmlAttribute] public int limit;
    [XmlAttribute] public int skillIdx;
    [XmlAttribute] public string animation = string.Empty; // kfm anim name
    [XmlAttribute] public int speed;
    [XmlAttribute] public int till;
    [XmlAttribute] public long initialCooltime;
    [XmlAttribute] public long cooltime;
    [XmlAttribute] public bool isKeepBattle;
    [XmlAttribute] public int idx;
    [XmlAttribute] public short level;
    [M2dArray] public int[] prob = new int[] { 100 };
    [XmlAttribute] public bool sequence;
    [M2dVector3] public Vector3 facePos; // clean out 0
    [XmlAttribute] public int faceTargetTick;
    [M2dVector3] public Vector3 pos;
    [XmlAttribute] public int faceTarget;
    [XmlAttribute] public string key = string.Empty;
    [XmlAttribute] public int value;
    [XmlAttribute] public string type = string.Empty; // rand, near, far, remove, talk, cutin, mid, add, nearAssociated, hasAdditional, randAssociated, rankAssociate, slave, grabbedUser, random, 2
    [XmlAttribute] public int rank;
    [XmlAttribute] public int additionalId;
    [XmlAttribute] public short additionalLevel;
    [XmlAttribute] public int from;
    [XmlAttribute] public int to;
    [M2dVector3] public Vector3 center; // clean out period commas
    [XmlAttribute] public AiTarget target = AiTarget.defaultTarget; // hostile, friendly
    [XmlAttribute] public bool noChangeWhenNoTarget;
    [XmlAttribute] public string message = string.Empty;
    [XmlAttribute] public int durationTick;
    [XmlAttribute] public int delayTick;
    [XmlAttribute] public bool isModify;
    [XmlAttribute] public float heightMultiplier;
    [XmlAttribute] public bool useNpcProb;
    [M2dVector3] public Vector3 destination;
    [XmlAttribute] public int npcId;
    [XmlAttribute] public int npcCountMax;
    [XmlAttribute] public int npcCount;
    [XmlAttribute] public int lifeTime; // sanitize a single float
    [M2dVector3] public Vector3 summonRot;
    [M2dVector3] public Vector3 summonPos; // sanitize double ,
    [M2dVector3] public Vector3 summonPosOffset;
    [M2dVector3] public Vector3 summonTargetOffset;
    [M2dVector3] public Vector3 summonRadius; // sanitize a float
    [XmlAttribute] public int group;
    [XmlAttribute] public SummonMaster master; // Slave, None
    [M2dArray] public SummonOption[] option = Array.Empty<SummonOption>(); // masterHP,hitDamage
    [XmlAttribute] public int triggerID;
    [XmlAttribute] public bool isRideOff;
    [M2dArray] public int[] rideNpcIDs = Array.Empty<int>();
    [XmlAttribute] public bool isRandom;
    [XmlAttribute] public float hpPercent;
    [XmlAttribute] public int id;
    [XmlAttribute] public bool isTarget;
    [XmlAttribute] public string effectName = string.Empty; // xml effect
    [XmlAttribute] public int groupID;
    [XmlAttribute] public string illust = string.Empty; // side popup asset name
    [XmlAttribute] public int duration;
    [XmlAttribute] public string script = string.Empty;
    [XmlAttribute] public string sound = string.Empty; // sound asset name
    [XmlAttribute] public string voice = string.Empty; // voice asset path
    [XmlAttribute] public int height;
    [XmlAttribute] public int radius;
    [XmlAttribute] public int timeTick;
    [XmlAttribute] public bool isShowEffect;
    [XmlAttribute] public string normal = string.Empty; // kfm anim name
    [XmlAttribute] public string reactable = string.Empty; // kfm anim name
    [XmlAttribute] public int interactID;
    [XmlAttribute] public string kfmName = string.Empty;
    [XmlAttribute] public int randomRoomID;
    [XmlAttribute] public int portalDuration;

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
