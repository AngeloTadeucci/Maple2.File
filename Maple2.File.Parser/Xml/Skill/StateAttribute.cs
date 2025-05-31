using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Skill;

public class StateAttribute {
    [XmlAttribute] public int battle;
    [XmlAttribute] public int speedRank;
    [XmlAttribute] public int superArmor;
    [XmlAttribute] public int superArmorApplyFieldType;
    [XmlAttribute] public int autoTargeting;
    [XmlAttribute] public int autoTargetingType;
    [XmlAttribute] public int moveType;
    [XmlAttribute] public int notKeepEffect;
    [XmlAttribute] public int keyIsDown;
    [XmlAttribute] public int useDefaultSkill;
    [XmlAttribute] public int useDefaultSkillID;
    [XmlAttribute] public int useInGameTime;
    [XmlAttribute] public int cooldownGroupID;
    [XmlAttribute] public int clearCooldownFromPVPZone;
    [XmlAttribute] public int ignoreReduceCooldown;
    [XmlAttribute] public int rechargeMaxCount;
    [XmlAttribute] public int rechargeOriginSkillID;
    [XmlAttribute] public int movingInMovekey;
    [XmlAttribute] public int splashMaxCount;

    // Ignored by client.
    [XmlAttribute] public int invokeEffectDisable;
    [XmlAttribute] public float autoTargetingMaxDegree;
    [XmlAttribute] public float autoTargetingMaxDistance;
    [XmlAttribute] public float autoTargetingMaxHeight;
    [XmlAttribute] public int autoTargetUseMove;
}

public class StateAttributeNew {
    [XmlAttribute] public int battle;
    [XmlAttribute] public int superArmor;
    [XmlAttribute] public int superArmorApplyFieldType;
    [XmlAttribute] public int autoTargeting;

    [XmlAttribute] public int autoTargetingType;
    [XmlAttribute] public int useDefaultSkill;
    [XmlAttribute] public int moveType;
    [XmlAttribute] public int notKeepEffect;

    [XmlAttribute] public int keyIsDown;

    [XmlAttribute] public int useDefaultSkillID;
    [XmlAttribute] public int useInGameTime;
    [XmlAttribute] public int cooldownGroupID;
    [XmlAttribute] public int clearCooldownFromPVPZone;
    [XmlAttribute] public int ignoreReduceCooldown;
    [XmlAttribute] public int rechargeMaxCount;

    [XmlAttribute] public int movingInMovekey;
    [XmlAttribute] public int splashMaxCount;

    [XmlAttribute] public bool rechargeShareOrigin;


}
