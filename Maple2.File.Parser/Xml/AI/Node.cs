using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Numerics;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AI;

public partial class Node {
    [XmlAttribute] public string name;

    [XmlElement] public List<Node> node = new List<Node>() ;
    [XmlElement] public List<Condition> condition = new List<Condition>();
    [XmlElement] public List<AiPreset> aiPreset = new List<AiPreset>();

    [XmlAttribute] public uint limit;
    [XmlAttribute] public byte skillIdx;
    [XmlAttribute] public string animation; // kfm anim name
    [XmlAttribute] public ushort speed;
    [XmlAttribute] public short till;
    [XmlAttribute] public ulong initialCooltime;
    [XmlAttribute] public ulong cooltime;
    [XmlAttribute] public bool isKeepBattle;
    [XmlAttribute] public ushort idx;
    [XmlAttribute] public byte level;
    [M2dArray] public uint[] prob = Array.Empty<uint>();
    [XmlAttribute] public bool sequence;
    [M2dVector3] public Vector3 facePos; // clean out 0
    [XmlAttribute] public ushort faceTargetTick;
    [XmlAttribute] public byte rob;
    [M2dVector3] public Vector3 pos;
    [XmlAttribute] public byte faceTarget;
    [XmlAttribute] public string key;
    [XmlAttribute] public int value;
    [XmlAttribute] public string type; // rand, near, far, remove, talk, cutin, mid, add, nearAssociated, hasAdditional, randAssociated, rankAssociate, slave, grabbedUser, random, 2
    [XmlAttribute] public byte rank;
    [XmlAttribute] public uint additionalId;
    [XmlAttribute] public ushort additionalLevel;
    [XmlAttribute] public uint from;
    [XmlAttribute] public uint to;
    [M2dVector3] public Vector3 center; // clean out period commas
    [XmlAttribute] public string target; // hostile, friendly, Me, SetUserValue, Distance, Slaves
    [XmlAttribute] public bool noChangeWhenNoTarget;
    [XmlAttribute] public string message;
    [XmlAttribute] public uint durationTick;
    [XmlAttribute] public uint delayTick;
    [XmlAttribute] public bool isModify;
    [XmlAttribute] public float heightMultiplier;
    [XmlAttribute] public bool useNpcProb;
    [M2dVector3] public Vector3 destination;
    [XmlAttribute] public uint npcId;
    [XmlAttribute] public ushort npcCountMax;
    [XmlAttribute] public ushort npcCount;
    [XmlAttribute] public uint lifeTime; // sanitize a single float
    [M2dVector3] public Vector3 summonRot;
    [M2dVector3] public Vector3 summonPos; // sanitize double ,
    [M2dVector3] public Vector3 summonPosOffset;
    [M2dVector3] public Vector3 summonTargetOffset;
    [M2dVector3] public Vector3 summonRadius; // sanitize a float
    [XmlAttribute] public ushort group;
    [XmlAttribute] public string master; // Slave, None
    [M2dArray] public string[] option = Array.Empty<string>(); // masterHP,hitDamage
    [XmlAttribute] public uint triggerID;
    [XmlAttribute] public bool isRideOff;
    [M2dArray] public uint[] rideNpcIDs = Array.Empty<uint>();
    [XmlAttribute] public bool isRandom;
    [XmlAttribute] public float hpPercent;
    [XmlAttribute] public uint id;
    [XmlAttribute] public bool isTarget;
    [XmlAttribute] public string effectName; // xml effect
    [XmlAttribute] public byte groupID;
    [XmlAttribute] public string illust; // side popup asset name
    [XmlAttribute] public ushort duration;
    [XmlAttribute] public string script;
    [XmlAttribute] public string sound; // sound asset name
    [XmlAttribute] public string voice; // voice asset path
    [XmlAttribute] public uint height;
    [XmlAttribute] public uint radius;
    [XmlAttribute] public int timeTick;
    [XmlAttribute] public bool isShowEffect;
    [XmlAttribute] public string normal; // kfm anim name
    [XmlAttribute] public string reactable; // kfm anim name
    [XmlAttribute] public uint interactID;
    [XmlAttribute] public string kfmName;
    [XmlAttribute] public byte randomRoomID;
    [XmlAttribute] public byte portalDuration;

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
