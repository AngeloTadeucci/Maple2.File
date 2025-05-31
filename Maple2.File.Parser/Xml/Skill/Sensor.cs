using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Skill;

public partial class Sensor {
    [XmlAttribute] public string rangeType = string.Empty;
    [XmlAttribute] public int distance;
    [XmlAttribute] public int height;
    [M2dVector3] public Vector3 rangeAdd;
    [XmlAttribute] public int sensorStartDelay;
    [XmlAttribute] public int sensorSplashStartDelay;
    [XmlAttribute] public bool sensorForceInvokeByInterval;
    [XmlAttribute] public int targetHasBuffID;
    [XmlAttribute] public bool targetHasBuffOwner; // 0
    [XmlAttribute] public int targetHasNotBuffID;
}
