using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Item;

public class Drop {
    [XmlAttribute] public string dropNif = string.Empty;

    [XmlAttribute] public string dropDisplay = string.Empty;
    // unknown delimited by '.'
}
