using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Map;

public class Optimize {
    [XmlAttribute] public bool fastglow;
    [XmlAttribute] public float fastshimmer;
}
