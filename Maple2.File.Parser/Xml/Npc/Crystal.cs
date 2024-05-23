using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc;

public class Crystals {
    [XmlElement] public List<Crystal> crystal;
}

public partial class Crystal {
    [XmlAttribute] public string id = string.Empty;
    [M2dArray] public int[] level = Array.Empty<int>();
    [M2dArray] public int[] price = Array.Empty<int>();
}
