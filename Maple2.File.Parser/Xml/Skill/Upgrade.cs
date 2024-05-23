using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Skill;

public partial class Upgrade {
    [XmlAttribute] public short level;
    [M2dArray] public int[] skillIDs = Array.Empty<int>();
    [M2dArray] public int[] skillLevels = Array.Empty<int>();
    [M2dArray] public int[] questIDs = Array.Empty<int>();

    // Ignored by client.
    [XmlAttribute] public int money;
}
