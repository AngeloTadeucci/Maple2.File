using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Skill;

public partial class Kinds {
    [XmlAttribute] public int type; // 0,1,2,3
    [XmlAttribute] public int subType; // 0,1,2,3,4,5,6,7,8,9
    [XmlAttribute] public int rangeType; // 0,1,2,3
    [XmlAttribute] public int groupType; // 0,2
    [XmlAttribute] public int jump; // SkillId
    [XmlAttribute] public string state = string.Empty; // gos*
    [XmlAttribute("continue")] public bool continueSkill;
    [XmlAttribute] public bool spRecoverySkill;
    [XmlAttribute] public int element; // 0,1,2,3,4,5,6,7
    [XmlAttribute] public int motionType; // 0
    [XmlAttribute] public string emotion = string.Empty;
    [XmlAttribute] public float offsetNameTag;
    [XmlAttribute] public float offsetHPBar;
    [XmlAttribute] public bool immediateActive;
    [XmlAttribute] public bool weaponDependency;
    [XmlAttribute] public bool unrideOnUse;
    [XmlAttribute] public bool releaseObjectWeapon = true;
    [XmlAttribute] public bool releaseStunState;
    [XmlAttribute] public bool disableWater;
    [XmlAttribute] public bool holdAttack;
    [M2dArray] public int[] groupIDs = Array.Empty<int>();

    // Ignored by client.
    [XmlAttribute] public int emotionNameTagOffset; // 0
    [XmlAttribute] public string changeSkillCheckEffectID = string.Empty; // int[]
    [XmlAttribute] public string changeSkillCheckEffectLevel = string.Empty; // int[]
    [XmlAttribute] public string changeSkillID = string.Empty; // int[]
    [XmlAttribute] public int emotionType; // 0,1,2
    [XmlAttribute] public bool unrideOnHit;
}

public partial class KindsNew {
    //[XmlAttribute] public int type; // 0,1,2,3
    //[XmlAttribute] public int subType; // 0,1,2,3,4,5,6,7,8,9
    [XmlAttribute] public int rangeType; // 0,1,2,3
    [XmlAttribute] public int groupType; // 0,2
    [XmlAttribute] public int jump; // SkillId
                                    // [XmlAttribute] public string state = string.Empty; // gos*
    [XmlAttribute("continue")] public bool continueSkill;
    // [XmlAttribute] public bool spRecoverySkill;
    [XmlAttribute] public int element; // 0,1,2,3,4,5,6,7
                                       // [XmlAttribute] public int motionType; // 0
                                       // [XmlAttribute] public string emotion = string.Empty;
    [XmlAttribute] public float offsetNameTag;
    // [XmlAttribute] public float offsetHPBar;
    [XmlAttribute] public int immediateActive;
    // [XmlAttribute] public bool weaponDependency;
    [XmlAttribute] public bool unrideOnUse;
    [XmlAttribute] public bool releaseObjectWeapon = true;
    // [XmlAttribute] public bool releaseStunState;
    [XmlAttribute] public bool disableWater;
    [XmlAttribute] public bool holdAttack;
    [M2dArray] public int[] groupIDs = Array.Empty<int>();

    [XmlAttribute] public bool superArmorApplyFieldType;
    //
    // // Ignored by client.
    // [XmlAttribute] public int emotionNameTagOffset; // 0
    // [XmlAttribute] public string changeSkillCheckEffectID = string.Empty; // int[]
    // [XmlAttribute] public string changeSkillCheckEffectLevel = string.Empty; // int[]
    // [XmlAttribute] public string changeSkillID = string.Empty; // int[]
    // [XmlAttribute] public int emotionType; // 0,1,2
    // [XmlAttribute] public bool unrideOnHit;
}
