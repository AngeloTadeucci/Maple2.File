using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Object;

public class FirstAdditionalEffect {
    [XmlAttribute] public int firstAdditionalEffectID;
    [XmlAttribute] public short firstAdditionalEffectLevel;
    [XmlAttribute] public int firstAdditionalTarget;
    [XmlAttribute] public float firstAdditionalRange;
    [XmlAttribute] public int firstAdditionalPopup;
}
