using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Item;

public class Function {
    [XmlAttribute] public string name = string.Empty;
    [XmlAttribute] public string parameter = string.Empty;
    [XmlAttribute] public int onlyShadowContinent;
}
