using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/smartpush.xml
[XmlRoot("ms2")]
public partial class SmartPushRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<SmartPush> _push;
}

public partial class SmartPush : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public string content = string.Empty;
    [XmlAttribute] public string actionType = string.Empty;
    [XmlAttribute] public int actionValue;
    [XmlAttribute] public long requireMeret;
    [XmlAttribute] public string[] requiredItem = Array.Empty<string>();
    [XmlAttribute] public string imgPath = string.Empty;
}
