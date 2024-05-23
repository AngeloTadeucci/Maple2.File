using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Object;

public class Forbidden {
    [XmlAttribute] public int forbidJump;
    [XmlAttribute] public int forbidClimb;
    [XmlAttribute] public int forbidSkill;
    [XmlAttribute] public int forbidPlayInstrument;
    [XmlAttribute] public int forbidExceptOwner;
}
