using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/constants.xml
[XmlRoot("ms2")]
public partial class Constants {
    [M2dFeatureLocale(Selector = "key")] private IList<Key> _v;

    public partial class Key : IFeatureLocale {
        [XmlAttribute] public string key = string.Empty;
        [XmlAttribute] public string value = string.Empty;
    }
}
