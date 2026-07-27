using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/darkstream.xml
[XmlRoot("ms2")]
public partial class DarkStreamRoot {
    [M2dFeatureLocale(Selector = "round")] private IList<DarkStreamReward> _reward;
}

public partial class DarkStreamReward : IFeatureLocale {
    [XmlAttribute] public int round;
    [XmlAttribute] public float expRate;
    [XmlAttribute] public int meso;
    [XmlAttribute] public int habi;
    [XmlAttribute] public string items = string.Empty;
}
