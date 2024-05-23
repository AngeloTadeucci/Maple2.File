using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Item;

public class Material {
    [XmlAttribute] public int ui;
    [XmlAttribute] public int attack;
}
