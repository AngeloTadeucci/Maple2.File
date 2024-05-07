using Maple2.File.Parser.Enum;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AI;

public partial class Condition {
    public string name = string.Empty;

    public List<Entry> entries = new List<Entry>();

    public int value;
    public int battleTimeBegin;
    public int battleTimeLoop;
    public int battleTimeEnd;
    public int skillIdx;
    public short skillLev;
    public bool isKeepBattle;
    public string key = string.Empty;
    public ConditionOp op = ConditionOp.Equal; // greaterEqual, lessEqual, equal, Greater, less, greater
    public int count;
    public bool useSummonGroup;
    public int summonGroup;
    public ConditionTargetState targetState; // grabTarget, holdme
    public int id;
    public short level;
    public int overlapCount;
    public bool isTarget;
    public int slaveCount;
    public ConditionOp slaveCountOp = ConditionOp.Equal; // Greater
    public string feature = string.Empty; // this will be filtered in Maple2.Ingest

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
