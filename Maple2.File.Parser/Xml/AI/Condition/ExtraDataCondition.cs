using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.AI;

public class ExtraDataCondition : ConditionEntry {
    public string key;
    public int value;
    public ConditionOp op = ConditionOp.Equal;
    public bool isKeepBattle;
}
