using System.Xml.Serialization;
using Maple2.File.Parser.Xml.Skill;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public class Spread {
    [XmlAttribute] public int type;
    [XmlAttribute] public int count;
    [XmlElement] public RegionSkill rangeProperty;
}
