using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Map;

public class Indoor {
    [XmlAttribute] public float type; // bit flags (0 = 1, 1 = 10, 2 = 100, ...)
}
