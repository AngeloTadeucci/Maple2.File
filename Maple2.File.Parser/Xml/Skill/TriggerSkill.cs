using System.ComponentModel;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Xml.AdditionalEffect;

namespace Maple2.File.Parser.Xml.Skill;

public partial class TriggerSkill {
    [XmlAttribute] public bool splash;
    [XmlAttribute] public bool randomCast;
    [M2dArray] public short[] level = Array.Empty<short>();
    [M2dArray] public int[] skillID = Array.Empty<int>();
    [M2dArray] public int[] linkSkillID = Array.Empty<int>();
    [XmlAttribute] public int overlapCount = 1; // 1
    [XmlAttribute] public int skillTarget; // 1,2,3,4
    [XmlAttribute, DefaultValue(1)] public int skillOwner = 1; // if 0 then 1?; 0,1,2,3,5
    [XmlAttribute] public uint delay;
    [XmlAttribute] public int removeDelay; // 0,1500
    [XmlAttribute] public int interval; // 0,1,100,300,400,500,1000,2000,2500
    [XmlAttribute] public bool immediateActive;
    [XmlAttribute] public int fireCount = 1; // 1,4,10,40,120,160,600
    [XmlAttribute] public bool nonTargetActive;
    [XmlAttribute] public bool useDirection;
    [XmlAttribute] public bool onlySensingActive;
    [XmlAttribute] public bool dependOnCasterState;
    [XmlAttribute] public bool activeByIntervalTick;
    [XmlAttribute] public bool dependOnDamageCount;
    [XmlAttribute] public bool independent;
    [XmlAttribute] public bool chain;
    [XmlAttribute, DefaultValue(150.0f)] public float chainDistance = 150.0f; // default to 150.0 if not float

    [XmlElement] public BeginCondition beginCondition;
}

public partial class ActionSkill {
    [XmlAttribute] public int skillID;
    [XmlAttribute] public short level;
    [XmlAttribute] public uint delay;
    [XmlAttribute] public int removeDelay; // 0,1500
    [XmlAttribute] public int interval; // 0,1,100,300,400,500,1000,2000,2500
    [XmlAttribute] public bool immediateActive;
    [XmlAttribute] public int fireCount = 1; // 1,4,10,40,120,160,600
    [XmlAttribute] public bool nonTargetActive;
    [XmlAttribute] public bool useDirection;
    [XmlAttribute] public bool onlySensingActive;
    [XmlAttribute] public bool dependOnCasterState;
    [XmlAttribute] public bool independent;
    [XmlAttribute] public bool chain;
    [XmlAttribute, DefaultValue(150.0f)] public float chainDistance = 150.0f; // default to 150.0 if not float
    [M2dArray] public int[] linkSkillID = Array.Empty<int>();

}

public partial class ActionAdditional {
    [XmlAttribute] public int additionalID;
    [XmlAttribute] public short level;
    [XmlAttribute] public int skillTarget;
    [XmlAttribute, DefaultValue(1)] public int skillOwner = 1; // if 0 then 1?; 0,1,2,3,5
    [XmlAttribute] public bool dependOnDamageCount;
    [XmlAttribute] public int overlapCount = 1; // 1
    [M2dArray] public int[] linkSkillID = Array.Empty<int>();

    [XmlElement] public Condition beginCondition;
}
