using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AI;

public partial class Condition {
    [XmlAttribute] public string name;

    [XmlElement] public List<Node> node = new List<Node>();
    [XmlElement] public List<AiPreset> aiPreset = new List<AiPreset>();

    [XmlAttribute] public int value;
    [XmlAttribute] public uint battleTimeBegin;
    [XmlAttribute] public uint battleTimeLoop;
    [XmlAttribute] public uint battleTimeEnd;
    [XmlAttribute] public byte skillIdx;
    [XmlAttribute] public byte skillLev;
    [XmlAttribute] public bool isKeepBattle;
    [XmlAttribute] public string key;
    [XmlAttribute] public string op; // greaterEqual, lessEqual, equal, Greater, less, greater
    [XmlAttribute] public byte count;
    [XmlAttribute] public bool useSummonGroup;
    [XmlAttribute] public byte summonGroup;
    [XmlAttribute] public string targetState; // grabTarget, holdme
    [XmlAttribute] public uint id;
    [XmlAttribute] public byte level;
    [XmlAttribute] public byte overlapCount;
    [XmlAttribute] public bool isTarget;
    //[XmlAttribute] public string feature; // feature name
    [XmlAttribute("feature")]
    public string _feature = string.Empty;
    public string Feature => _feature;
    [XmlAttribute] public ushort slaveCount;
    [XmlAttribute] public string slaveCountOp; // Greater

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
