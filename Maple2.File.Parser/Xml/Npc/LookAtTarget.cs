using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Npc;

public class LookAtTarget {
    [XmlAttribute] public string targetdummy = string.Empty;
    [XmlAttribute] public float distance;
    [XmlAttribute] public int lookAtMyPCWhenTalking = 1;
    [XmlAttribute] public int useTalkMotion = 1;
}
