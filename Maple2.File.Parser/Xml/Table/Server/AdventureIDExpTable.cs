using System.Collections.Generic;
using System.Xml.Serialization;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/AdventureIDExpTable.xml
[XmlRoot("ms2")]
public class AdventureIdExpTableRoot {
    [XmlElement] public List<AdventureIdExpTable> exp;
}

public class AdventureIdExpTable {
    [XmlAttribute] public int id;
    [XmlAttribute] public long value;
    [XmlAttribute] public AdventureExpType expType;
}
