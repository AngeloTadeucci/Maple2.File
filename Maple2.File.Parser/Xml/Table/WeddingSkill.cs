using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/weddingskill.xml
[XmlRoot("ms2")]
public partial class WeddingSkillRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<WeddingSkill> _v;
}

public partial class WeddingSkill : IFeatureLocale {
    [XmlAttribute] public int id;
    [M2dEnum] public WeddingSkillType type;
    [XmlAttribute] public byte requireGrade;
    [XmlAttribute] public int additionalEffectID;
    [XmlAttribute] public float startValue;
    [XmlAttribute] public float addValue;
    [XmlAttribute] public int maxCount;
    [XmlAttribute] public int itemID;
    [XmlAttribute] public byte grade;
    [XmlAttribute] public int count;
}
