using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Skill.Property;

public class PetTamingProperty {
    [XmlAttribute] public int tamingGroup;
    [XmlAttribute] public int trapLevel;
    [XmlAttribute] public int tamingPoint;
    [XmlAttribute] public bool forcedTaming;
}
