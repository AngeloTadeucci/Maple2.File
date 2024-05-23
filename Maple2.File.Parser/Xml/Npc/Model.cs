using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc;

public partial class Model {
    [XmlAttribute] public string kfm = string.Empty;
    [XmlAttribute] public float scale = 1.0f;
    [XmlAttribute] public float anispeed = 1.0f;
    [XmlAttribute] public bool anispeedfix;
    [XmlAttribute] public int spawnAlphaAnimation = 1;
    [M2dVector3] public Vector3 offset;
}
