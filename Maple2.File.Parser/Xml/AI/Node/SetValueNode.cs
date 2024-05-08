namespace Maple2.File.Parser.Xml.AI;

public class SetValueNode : NodeEntry {
    public string key = string.Empty;
    public int value;
    public long initialCooltime;
    public long cooltime;
    public bool isModify;
    public bool isKeepBattle;
}

public class SetMasterValueNode : NodeEntry {
    public string key = string.Empty;
    public int value;
    public bool isRandom;
    public long cooltime;
    public bool isModify;
    public bool isKeepBattle;
}

public class SetSlaveValueNode : NodeEntry {
    public string key = string.Empty;
    public int value;
    public bool isRandom;
    public long cooltime;
    public bool isModify;
    public bool isKeepBattle;
}

public class SetValueRangeTargetNode : NodeEntry {
    public string key = string.Empty;
    public int value;
    public int height;
    public int radius;
    public long cooltime;
    public bool isModify;
    public bool isKeepBattle;
}
