using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Item;

public class Skill {
    [XmlAttribute] public int skillID;
    [XmlAttribute] public short skillLevel = 1;
}
