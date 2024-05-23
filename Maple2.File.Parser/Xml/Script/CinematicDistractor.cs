using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Script;

public partial class CinematicDistractor {
    [XmlAttribute] public string text = string.Empty;
    [M2dArray(Name = "goto")] public int[] @goto = Array.Empty<int>();
    [M2dArray] public int[] gotoFail = Array.Empty<int>();
}
