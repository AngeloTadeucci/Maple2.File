using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Item;

public class Badge {
    [XmlAttribute] public int system;
    [XmlAttribute] public string property = string.Empty;
}
