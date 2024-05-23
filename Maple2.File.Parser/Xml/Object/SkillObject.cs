using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Object;

public class SkillObject {
    [XmlAttribute] public int skillID;
    [XmlAttribute] public short skillLevel;
    [XmlAttribute] public int friendly;
}
