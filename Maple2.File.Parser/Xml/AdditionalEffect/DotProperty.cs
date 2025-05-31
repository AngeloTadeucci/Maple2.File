using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public class DotDamageProperty {
    [XmlAttribute] public int type; // 0,1,2,3,6
    [XmlAttribute] public bool useGrade;
    [XmlAttribute] public long value;
    [XmlAttribute] public float rate;
    [XmlAttribute] public int spValue;
    [XmlAttribute] public int epValue;
    [XmlAttribute] public int hand; // 0
    [XmlAttribute] public int element; // 0,1,2,3,4,5,6,7
    [XmlAttribute] public float damageByTargetMaxHP;
    [XmlAttribute] public float casterRecoveryHpByDamage;
    [XmlAttribute] public int soundMaterial; // 0,1,4,100,101,102,103,104,105,106,1000
    [XmlAttribute] public bool isConstDotDamageValue;
    [XmlAttribute] public bool notKill;
    [XmlAttribute] public long damageRefBap;
    [XmlAttribute] public long damageRefWap;
    [XmlAttribute] public long damageRefTap;
}

public class DotBuffProperty {
    [XmlAttribute] public int target; // 0,1
    [XmlAttribute] public int buffID;
    [XmlAttribute] public short buffLevel;
}
