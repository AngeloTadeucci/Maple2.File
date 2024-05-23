using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Map;

public class Camera {
    [XmlAttribute] public float distance;
    [XmlAttribute] public float hangle;
    [XmlAttribute] public float vangle;
    [XmlAttribute] public float zoomOutHeightOffset = 60.0f;
    [XmlAttribute] public float zoomInHeightOffset = 95.0f;
    [XmlAttribute] public bool useFileSetting;
    [XmlAttribute] public string dummyTargetPos = string.Empty;
    [XmlAttribute] public string usedummytarget = string.Empty;
}
