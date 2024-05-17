using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/AdventureExpTable.xml
[XmlRoot("ms2")]
public partial class AdventureExpTableRoot {
    [M2dFeatureLocale(Selector = "type")] private IList<AdventureExpTable> _exp;
}

public partial class AdventureExpTable : IFeatureLocale {
    [XmlAttribute] public AdventureExpType type;
    [XmlAttribute] public long value;
}
