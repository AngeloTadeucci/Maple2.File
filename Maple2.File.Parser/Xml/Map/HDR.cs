using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Map;

public class HDR {
    [XmlAttribute] public float threshold;
    [XmlAttribute] public float offset;
    [XmlAttribute] public float middlegray;
    [XmlAttribute] public float bloomscale;
    [XmlAttribute] public float glowscale = 0.1f;
}
