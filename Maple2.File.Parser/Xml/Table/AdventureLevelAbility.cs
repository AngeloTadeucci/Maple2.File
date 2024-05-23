using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/adventurelevelability.xml
[XmlRoot("ms2")]
public partial class AdventureLevelAbilityRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<AdventureLevelAbility> _ability;
}

public partial class AdventureLevelAbility : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int requireLevel;
    [XmlAttribute] public int interval;
    [XmlAttribute] public int maxCount;
    [XmlAttribute] public int additionalEffectId;
    [XmlAttribute] public float startValue;
    [XmlAttribute] public float addValue;
}
