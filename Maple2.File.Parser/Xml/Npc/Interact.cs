using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Npc;

public class Interact {
    [XmlAttribute] public string interactFunction = string.Empty;
    [XmlAttribute] public string interactCastingAnimation = string.Empty;
    [XmlAttribute] public int interactCastingTime;
    [XmlAttribute] public int interactCoolTime;
    [XmlAttribute] public bool interactIsShowCastingBar;
}
