using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Npc;

public class Push {
    [XmlAttribute] public float back = 1.0f;
    [XmlAttribute] public float up = 1.0f;
    [XmlAttribute] public float knockback = 1.0f;
}
