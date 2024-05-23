using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Map;

public partial class Drop {
    [XmlAttribute] public int maplevel = 1;
    [XmlAttribute] public int droprank = 1;
    [M2dArray] public int[] globalDropBoxID = Array.Empty<int>();
}
