using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Object;

public class Spawner {
    [XmlAttribute] public float radius;
    [XmlAttribute] public int npcCount;
    [XmlAttribute] public int npcID = 3;
    [XmlAttribute] public float regenCheckTime;
}
