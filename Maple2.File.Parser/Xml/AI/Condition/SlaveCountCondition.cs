using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.AI;

public class SlaveCountCondition : ConditionEntry {
    public int count;
    public bool useSummonGroup;
    public int summonGroup;

    public int slaveCount;
    public ConditionOp slaveCountOp = ConditionOp.Equal;
}
