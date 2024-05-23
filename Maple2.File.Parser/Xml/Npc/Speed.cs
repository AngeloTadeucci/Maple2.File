using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Npc;

public class Speed {
    [XmlAttribute] public float rotation;
    [XmlAttribute] public float walk;
    [XmlAttribute] public float run;
}
