using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Skill.Property;

public class RecoveryProperty {
    [XmlAttribute] public long spValue;
    [XmlAttribute] public float spRate;
}
