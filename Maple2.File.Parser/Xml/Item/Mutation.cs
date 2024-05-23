using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Item;

public partial class Mutation {
    [XmlAttribute] public int interval = 2;
    [M2dArray] public string[] assets = Array.Empty<string>();
    [M2dArray] public int[] skills = Array.Empty<int>();
    [XmlAttribute] public string changeeffect = string.Empty;
}
