using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Item;

public partial class Option {
    [XmlAttribute] public int title;
    [XmlAttribute("static")] public int @static;
    [XmlAttribute] public int random;
    [XmlAttribute] public int constant;
    [XmlAttribute] public int staticMakeType;
    [XmlAttribute] public int randomMakeType;
    [XmlAttribute] public int constantMakeType;
    [XmlAttribute] public int optionRandom;
    [XmlAttribute] public float optionLevelFactor = 1.0f;
    [M2dNullable] public float? globalOptionLevelFactor;
    [XmlAttribute] public int optionID;
}
