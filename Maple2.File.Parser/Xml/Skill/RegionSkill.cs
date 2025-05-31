using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Skill;

public partial class RegionSkill {
    [XmlAttribute] public int includeCaster; // 0,1,2
    [XmlAttribute] public string rangeType = string.Empty; // box, cylinder, frustum, hole_cylinder
    [XmlAttribute] public float distance;
    [M2dVector3] public Vector3 rangeAdd;
    [M2dVector3] public Vector3 rangeOffset;
    [XmlAttribute] public float rangeZRotateDegree;
    [XmlAttribute] public float height;
    [XmlAttribute] public float width;
    [XmlAttribute] public float endWidth;
    [XmlAttribute] public int applyTarget; // 0,1,2,3,5,6,7,8
    [XmlAttribute] public int castTarget; // 0,1,2,3,5,7
    [XmlAttribute] public int targetHasBuffID;
    [XmlAttribute] public int targetHasBuffOverlapCount; // 0
    [XmlAttribute] public int targetHasNotBuffID;
    [XmlAttribute] public bool targetHasBuffOwner;
    [XmlAttribute] public int targetSelectType; // 0,1,2,3
    [XmlAttribute] public bool targetSelectParty;
    [XmlAttribute] public bool targetSelectGuild;
    [XmlAttribute] public int targetStatCompare; // 0,4
    [XmlAttribute] public int targetStatCompareFunction; // 0,1,3
    [M2dArray] public int[] applyTargetIgnoreNpcRanks = Array.Empty<int>();

    // SensorProperty ONLY
    [XmlAttribute] public int sensorStartDelay; // 0,500,1000,2000,3000
    [XmlAttribute] public int sensorSplashStartDelay; // 0,300,800,1000
    [XmlAttribute] public bool sensorForceInvokeByInterval;

    // Ignored by client.
    [XmlAttribute] public bool targetSelectHasBuffType; // 0
    [XmlAttribute] public bool onlyTargetSelectHasBuff; // 0
}

public partial class RegionSkillNew {
    [XmlAttribute] public int includeCaster; // 0,1,2
    [XmlAttribute] public string rangeType = string.Empty; // box, cylinder, frustum, hole_cylinder
    [XmlAttribute] public float distance;
    [M2dVector3] public Vector3 rangeAdd;
    [M2dVector3] public Vector3 rangeOffset;
    [XmlAttribute] public float rangeZRotateDegree;
    [XmlAttribute] public float height;
    [XmlAttribute] public float width;
    [XmlAttribute] public float endWidth;
    [XmlAttribute] public int applyTarget; // 0,1,2,3,5,6,7,8
    [XmlAttribute] public int castTarget; // 0,1,2,3,5,7
    [XmlAttribute] public int targetHasBuffID;
    [XmlAttribute] public int targetHasBuffOverlapCount; // 0
    [XmlAttribute] public int targetHasNotBuffID;
    [XmlAttribute] public bool targetHasBuffOwner;
    [XmlAttribute] public int targetSelectType; // 0,1,2,3
    [XmlAttribute] public bool targetSelectParty;
    [XmlAttribute] public bool targetSelectGuild;
    [XmlAttribute] public int targetStatCompare; // 0,4
    [XmlAttribute] public int targetStatCompareFunction; // 0,1,3
    [M2dArray] public int[] applyTargetIgnoreNpcRanks = Array.Empty<int>();

    // Ignored by client.
    [XmlAttribute] public bool targetSelectHasBuffType; // 0
    [XmlAttribute] public bool onlyTargetSelectHasBuff; // 0
}
