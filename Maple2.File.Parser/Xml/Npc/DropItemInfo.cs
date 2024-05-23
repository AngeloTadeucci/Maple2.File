using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc;

public partial class DropItemInfo {
    [XmlAttribute] public float dropHeight;
    [XmlAttribute] public float dropDistanceBase = 50.0f;
    [XmlAttribute] public int dropDistanceRandom = 100;
    [XmlAttribute] public float fireVelocity = 100.0f;
    [M2dArray] public int[] globalDropBoxId = Array.Empty<int>();
    [M2dArray] public int[] globalDeadDropBoxId = Array.Empty<int>();
    [M2dArray] public int[] individualDropBoxId = Array.Empty<int>();
    [M2dArray] public int[] globalHitDropBoxId = Array.Empty<int>();
    [M2dArray] public int[] individualHitDropBoxId = Array.Empty<int>();

    // Ignored by client.
    [XmlAttribute] public string globalDropBoxIdLevel1 = string.Empty;
    [XmlAttribute] public string globalDropBoxIdLevel2 = string.Empty;
    [XmlAttribute] public string globalDropBoxIdLevel3 = string.Empty;
}
