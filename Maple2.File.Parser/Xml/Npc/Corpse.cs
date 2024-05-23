using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc;

public partial class Corpse {
    [XmlAttribute] public float width;
    [XmlAttribute] public float height;
    [XmlAttribute] public float depth;
    [XmlAttribute] public float added;
    [XmlAttribute] public float offsetNametag;
    [XmlAttribute] public int hitAble;
    [M2dVector3] public Vector3 rotation;
    [XmlAttribute] public string corpseEffect = string.Empty;
}
