using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc;

public partial class Dead {
    [XmlAttribute] public float time = 2.0f;
    [M2dArray] public string[] defaultaction = Array.Empty<string>();
    [M2dArray] public string[] upaction = Array.Empty<string>();
    [XmlAttribute] public int revival;
    [XmlAttribute] public int count = 1;
    [XmlAttribute] public float lifeTime;
    [XmlAttribute] public int extendRoomTime;

    // Ignored by client.
    [XmlAttribute] public int slowLastHit;
}
