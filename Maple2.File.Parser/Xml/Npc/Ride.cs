using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc;

public partial class Ride {
    [XmlAttribute] public float rideScale;
    [XmlAttribute] public string rideBone = string.Empty;
    [XmlAttribute] public string rideAnimation = string.Empty;
    [M2dVector3] public Vector3 rideTranslation;
    [M2dVector3] public Vector3 rideRotation;
    [XmlAttribute] public float rideSpeed;
    [XmlAttribute] public string rideSkill = string.Empty;
    [XmlAttribute] public int rideSkill2;
}
