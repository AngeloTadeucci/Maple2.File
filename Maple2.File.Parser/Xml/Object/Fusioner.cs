using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Object;

public class Fusioner {
    [XmlAttribute] public int temperature;
    [XmlAttribute] public int sacrifice;
}
