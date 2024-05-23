using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public class ReflectProperty {
    [XmlAttribute] public float reflectionRate;
    [XmlAttribute] public int reflectionAdditionalEffectId;
    [XmlAttribute] public short reflectionAdditionalEffectLevel;
    [XmlAttribute] public int reflectionCount;
    [XmlAttribute] public int physicalReflectionValue;
    [XmlAttribute] public float physicalReflectionRate;
    [XmlAttribute] public int physicalReflectionRateLimit;
    [XmlAttribute] public int magicalReflectionValue;
    [XmlAttribute] public float magicalReflectionRate;
    [XmlAttribute] public int magicalReflectionRateLimit;
    [XmlAttribute] public float reflectionDamageReduceRate;
}
