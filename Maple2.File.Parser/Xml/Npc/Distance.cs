using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Npc;

public class Distance {
    [XmlAttribute] public float avoid;
    [XmlAttribute] public float sight;
    [XmlAttribute] public float sightHeightUP;
    [XmlAttribute] public float sightHeightDown;
    [XmlAttribute] public float customLastSightRadius;
    [XmlAttribute] public float customLastSightHeightUp;
    [XmlAttribute] public float customLastSightHeightDown;
}
