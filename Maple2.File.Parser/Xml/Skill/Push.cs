using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Skill;

public class Push {
    [XmlAttribute] public float up;
    [XmlAttribute] public float back;
}
