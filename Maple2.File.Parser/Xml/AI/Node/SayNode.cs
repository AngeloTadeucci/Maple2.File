namespace Maple2.File.Parser.Xml.AI;

public class SayNode : NodeEntry {
    public string message = string.Empty;
    public int prob = 100;
    public int durationTick;
    public int delayTick;
    public long initialCooltime;
    public long cooltime;
    public bool isKeepBattle;
}
