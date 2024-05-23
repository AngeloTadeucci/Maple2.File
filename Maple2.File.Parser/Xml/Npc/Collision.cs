using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Npc;

public class Collision {
    [XmlAttribute] public string shape = string.Empty;
    [XmlAttribute] public float width;
    [XmlAttribute] public float height;
    [XmlAttribute] public float depth;
    [XmlAttribute] public int widthOffset;
    [XmlAttribute] public int depthOffset;
    [XmlAttribute] public int heightOffset;
}
