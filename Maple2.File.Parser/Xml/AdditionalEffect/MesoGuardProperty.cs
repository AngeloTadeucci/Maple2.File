using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public class MesoGuardProperty {
    [XmlAttribute] public float defensiveDamageRate;
    [XmlAttribute] public float consumeMoneyByDamage;
}
