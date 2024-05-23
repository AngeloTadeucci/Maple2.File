using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Object;

public class OpenWeb {
    [XmlAttribute] public int opentype;
    [XmlAttribute] public string target = string.Empty;
    [XmlAttribute] public string webURL = string.Empty;
}
