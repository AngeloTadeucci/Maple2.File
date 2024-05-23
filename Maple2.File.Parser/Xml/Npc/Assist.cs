using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Npc;

public class Assist {
    [XmlAttribute] public int assistType1SkillCount;
    [XmlAttribute] public int assistType2SkillCount;
    [XmlAttribute] public int assistType2CheckTick;
}
