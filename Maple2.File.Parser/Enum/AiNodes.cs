namespace Maple2.File.Parser.Enum;

public enum ConditionTargetState {
    grabTarget,
    holdme
}

public enum ConditionOp {
    Equal,
    Greater,
    Less,
    GreaterEqual,
    LessEqual,

    equal = Equal,
    greaterEqual = GreaterEqual,
    lessEqual = LessEqual,
    greater = Greater,
    less = Less
}

public enum SummonOption {
    none,
    masterHP,
    hitDamage,
    linkHP
}

public enum SummonMaster {
    Master,
    Slave,
    None
}

public enum AiTarget {
    defaultTarget,
    hostile,
    friendly
}