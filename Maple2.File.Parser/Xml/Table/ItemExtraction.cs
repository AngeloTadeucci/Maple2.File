using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/itemextraction.xml
[XmlRoot("ms2")]
public partial class ItemExtractionRoot {
    [M2dFeatureLocale(Selector = "TargetItemID")] private IList<ItemExtraction> _key;
}

public partial class ItemExtraction : IFeatureLocale {
    [XmlAttribute] public int TargetItemID;
    [XmlAttribute] public int TryCount;
    [XmlAttribute] public int ScrollCount;
    [XmlAttribute] public int ResultItemID;
}
