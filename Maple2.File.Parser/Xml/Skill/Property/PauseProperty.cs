using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Skill.Property;

public class PauseProperty {
    [XmlAttribute] public float pauseDuration;
    [XmlAttribute] public float pauseShakeDuration;
    [XmlAttribute] public float pauseAmp;
}
