using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Item;

public partial class Basic {
    [XmlAttribute] public int originID;
    [XmlAttribute] public int friendly = 1;
    [XmlAttribute] public string stringTag = string.Empty;
    [M2dArray] public string[] attributeTag = Array.Empty<string>();
}
