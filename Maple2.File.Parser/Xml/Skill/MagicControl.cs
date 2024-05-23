using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Skill;

public class MagicControl {
    [XmlAttribute] public bool enable;
    [XmlAttribute] public float moveSpeed; // * 0.0099999998
    [XmlAttribute] public float duration;
    [XmlAttribute] public float maxDistance;
}
