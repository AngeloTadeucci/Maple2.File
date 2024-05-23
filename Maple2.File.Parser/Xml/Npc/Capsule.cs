using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Npc;

public class Capsule {
    [XmlAttribute] public float radius;
    [XmlAttribute] public float height;
    [XmlAttribute] public int ignore;
}
