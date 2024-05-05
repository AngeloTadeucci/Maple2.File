using Maple2.File.Parser.Enum;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AI;

public partial class Condition : IFeatureLocale {
    [XmlAttribute] public string name = string.Empty;

    [XmlElement] public List<Node> node;
    [XmlElement] public List<AiPreset> aiPreset;

    [XmlAttribute] public int value;
    [XmlAttribute] public int battleTimeBegin;
    [XmlAttribute] public int battleTimeLoop;
    [XmlAttribute] public int battleTimeEnd;
    [XmlAttribute] public int skillIdx;
    [XmlAttribute] public short skillLev;
    [XmlAttribute] public bool isKeepBattle;
    [XmlAttribute] public string key = string.Empty;
    [XmlAttribute] public ConditionOp op = ConditionOp.Equal; // greaterEqual, lessEqual, equal, Greater, less, greater
    [XmlAttribute] public int count;
    [XmlAttribute] public bool useSummonGroup;
    [XmlAttribute] public int summonGroup;
    [XmlAttribute] public ConditionTargetState targetState; // grabTarget, holdme
    [XmlAttribute] public int id;
    [XmlAttribute] public short level;
    [XmlAttribute] public int overlapCount;
    [XmlAttribute] public bool isTarget;
    [XmlAttribute] public int slaveCount;
    [XmlAttribute] public ConditionOp slaveCountOp = ConditionOp.Equal; // Greater

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
