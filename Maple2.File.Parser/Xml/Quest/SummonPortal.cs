using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Quest;

public class SummonPortal {
    [XmlAttribute] public int fieldID;
    [XmlAttribute] public int portalID;
}
