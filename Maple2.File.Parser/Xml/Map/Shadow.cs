using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Map;

public class Shadow {
    [XmlAttribute] public float intensity = 1.0f;
    [XmlAttribute] public float simpleshadow = 1.0f;
}
