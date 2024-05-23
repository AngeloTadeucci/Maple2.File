using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Map;

public class BGM {
    [XmlAttribute] public int id;
    [XmlAttribute] public int param;
    [XmlAttribute] public float value;
    [XmlAttribute] public int boss;
    [XmlAttribute] public int bossParam;
    [XmlAttribute] public float bossValue;
    [XmlAttribute] public string enterSystemSound = string.Empty;

    // Ignored by client.
    [XmlAttribute] public int lengthms;
    [XmlAttribute] public int fadeIn;
    [XmlAttribute] public int fadeOut;
}
