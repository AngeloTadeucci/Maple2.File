using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public partial class MotionProperty {
    [XmlAttribute] public string sequenceName = string.Empty;
    [XmlAttribute] public string startEffect = string.Empty;
    [XmlAttribute] public string keepEffect = string.Empty;
    [XmlAttribute] public string stopEffect = string.Empty;
    [XmlAttribute] public string invokeEffect = string.Empty;
    [XmlAttribute] public bool IgnoreOptimalHideStartEffect;
    [XmlAttribute] public bool IgnoreOptimalHideKeepEffect;
    [XmlAttribute] public bool IgnoreOptimalHideStopEffect;
    [XmlAttribute] public bool IgnoreOptimalHideInvokeEffect;
    [M2dArray] public int[] disableEffectStates = Array.Empty<int>();
    [XmlAttribute] public bool hide;
    [M2dArray] public int[] clearCondition = Array.Empty<int>();
    [XmlAttribute] public float alphaBlending = 1.0f;
    [XmlAttribute] public int stun; // 0,1,2,3,4,5,6,7,8,99
    [XmlAttribute] public string stunAnimation = string.Empty;
    [XmlAttribute] public bool confusionMove;
    [XmlAttribute] public bool soundPitch;
    [XmlAttribute] public int abnormalImmuneBreak; // 0,1,5,40,81,85,90,91,95,99,100,999
    [XmlAttribute] public int revival; // 0
    [XmlAttribute] public int holdWeapon = 1; // 1
    [XmlAttribute] public float scale;
    [XmlAttribute] public float sequenceSpeed;
    [XmlAttribute] public float knockBackDistance;
    [XmlAttribute] public bool ignoreCollisionGroups; // 0
    [XmlAttribute] public bool noFly;
    [XmlAttribute] public int superArmor; // 0,1,2,3
    [XmlAttribute] public int superArmorApplyFieldType; // 0,1
    [XmlAttribute] public int skillUseDisable; // 0,2,4,6,12,40,60,62,830
    [XmlAttribute] public bool useFixedZRotation;
    [XmlAttribute] public float fixedZRotation;
    [M2dArray] public int[] skillUseDisableIDs = Array.Empty<int>();

    // only on New Xml
    [XmlElement] public OverlapKeepEffectProperty OverlapKeepEffectProperty;

    // Ignored by client.
    // [XmlAttribute] public int confusion; // 0
    // [XmlAttribute] public int chaosMode; // 0
    // [XmlAttribute] public string materialEffect = string.Empty;
}

public class OverlapKeepEffectProperty {
    [XmlElement] public OverlapData start;
    [XmlElement] public OverlapData keep;
    [XmlElement] public OverlapData end;
}

public class OverlapData {
    [XmlElement] public List<Overlap> overlap = [];
}

public class Overlap {
    [XmlAttribute] public int count;
    [XmlAttribute] public string effect = string.Empty;
}
