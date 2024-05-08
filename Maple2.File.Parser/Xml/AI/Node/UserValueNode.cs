namespace Maple2.File.Parser.Xml.AI;

public class TriggerSetUserValueNode : NodeEntry {
    public int triggerID;
    public string key = string.Empty;
    public int value;
    public long cooltime;
    public bool isKeepBattle;
}

public class TriggerModifyUserValueNode : NodeEntry {
    public int triggerID;
    public string key = string.Empty;
    public int value;
}
