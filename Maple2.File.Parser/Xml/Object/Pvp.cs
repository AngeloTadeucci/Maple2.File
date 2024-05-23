using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Object;

public class Pvp {
    [XmlAttribute] public bool enable;
    [XmlAttribute] public int team;
}
