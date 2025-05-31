using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Skill.Property;

public class DamageProperty {
    [XmlAttribute] public int count = 1;
    [XmlAttribute] public int hand; // 0,1,2
    [XmlAttribute] public float rate;
    [XmlAttribute] public float hitSpeedRate = 1.0f;
    [XmlAttribute] public float hitPauseTime;
    [XmlAttribute] public float damagedVibrateRatio = 1.0f;
    [XmlAttribute] public long value;
    [XmlAttribute] public int isConstDamageValue;
    [XmlAttribute] public float damageByTargetMaxHP;
    [XmlAttribute] public long constDamageByTargetHP;
    [XmlAttribute] public long constDamageByTargetSP;
    [XmlAttribute] public string effectHit = string.Empty;
    [XmlAttribute] public string effectRemain = string.Empty;
    [XmlAttribute] public bool IgnoreOptimalHideDamageHitEffect;
    [XmlAttribute] public bool IgnoreOptimalHideDamageRemainEffect;
    [XmlAttribute] public int push; // -1,0,1,2,3,4,5
    [XmlAttribute] public float pushdistance;
    [XmlAttribute] public float pushduration;
    [XmlAttribute] public float pushprob = 1.0f;
    [XmlAttribute] public int pushEaseType; // if n < 0 || n > 2, set to 0; 0,1,2
    [XmlAttribute] public int pushApplyField; // 0,1,2
    [XmlAttribute] public int pushDown; // 0,1,150
    [XmlAttribute] public bool pushFall;
    [XmlAttribute] public int pushPriority; // 0,1,2,3,4,5,10,15,50,99
    [XmlAttribute] public int pushPriorityHitImmune; // 0,1,150,200,300,1600
    [XmlAttribute] public string pushAnimation = string.Empty;
    [XmlAttribute] public float pushUpDistance;
    [XmlAttribute] public int attackMaterial; // 0,1,2,3,4,5,6,7,8,9,11,100,101,102,103,104,105,106,1000,1103
    [XmlAttribute] public bool jumpHitIgnore;
    [XmlAttribute] public bool superArmorBreak;
    [XmlAttribute] public bool invokeEffectDisable;
    [XmlAttribute] public bool damageEventDisable;
    [XmlAttribute] public long damageRefBap;
    [XmlAttribute] public long damageRefWap;
    [XmlAttribute] public long damageRefTap;
}

public partial class DamagePropertyNew {
    [XmlAttribute] public int count = 1;
    // [XmlAttribute] public int hand; // 0,1,2
    [XmlAttribute] public float rate;
    [XmlAttribute] public float hitSpeedRate = 1.0f;
    [XmlAttribute] public float hitPauseTime;
    [XmlAttribute] public float damagedVibrateRatio = 1.0f;
    [XmlAttribute] public long value;
    [XmlAttribute] public int isConstDamageValue;
    [XmlAttribute] public float damageByTargetMaxHP;
    [XmlAttribute] public long constDamageByTargetHP;
    [XmlAttribute] public long constDamageByTargetSP;
    [XmlAttribute] public string effectHit = string.Empty;
    [XmlAttribute] public string effectRemain = string.Empty;
    [XmlAttribute] public bool IgnoreOptimalHideDamageHitEffect;
    [XmlAttribute] public bool IgnoreOptimalHideDamageRemainEffect;
    [XmlAttribute] public int push; // -1,0,1,2,3,4,5
    [XmlAttribute] public float pushdistance;
    [XmlAttribute] public float pushduration;
    [XmlAttribute] public float pushprob = 1.0f;
    [XmlAttribute] public int pushEaseType; // if n < 0 || n > 2, set to 0; 0,1,2
    [XmlAttribute] public int pushApplyField; // 0,1,2
    [XmlAttribute] public int pushDown; // 0,1,150
    [XmlAttribute] public bool pushFall;
    [XmlAttribute] public int pushPriority; // 0,1,2,3,4,5,10,15,50,99
    [XmlAttribute] public int pushPriorityHitImmune; // 0,1,150,200,300,1600
    [XmlAttribute] public string pushAnimation = string.Empty;
    [XmlAttribute] public float pushUpDistance;
    [XmlAttribute] public int attackMaterial; // 0,1,2,3,4,5,6,7,8,9,11,100,101,102,103,104,105,106,1000,1103
    [XmlAttribute] public bool jumpHitIgnore;
    [XmlAttribute] public bool superArmorBreak;
    [XmlAttribute] public bool invokeEffectDisable;
    [XmlAttribute] public int damageEventDisable;
    [XmlAttribute] public int stateHitIgnore;
    [M2dArray] public int[] stateHitOnly = Array.Empty<int>();
    [XmlAttribute] public long damageRefBap;
    [XmlAttribute] public long damageRefWap;
    [XmlAttribute] public long damageRefTap;
}
