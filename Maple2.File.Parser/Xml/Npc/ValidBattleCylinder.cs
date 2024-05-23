using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Npc;

public class ValidBattleCylinder {
    [XmlAttribute] public float radius;
    [XmlAttribute] public float height;
}
