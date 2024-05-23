using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public class ConsumeProperty {
    [XmlAttribute] public float hpRate;
    [XmlAttribute] public float spRate;
    [XmlAttribute] public float spConsumeChangeHpRate;
}
