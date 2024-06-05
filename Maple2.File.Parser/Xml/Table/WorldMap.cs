using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/newworldmap.xml
[XmlRoot("ms2worldmap")]
public partial class WorldMapRoot {
    [M2dFeatureLocale] private IList<WorldMap> _environment;
}

public partial class WorldMap : IFeatureLocale {
    [XmlElement] public List<Map> map;

    // <map code = "63000011" x="-2" y="-3 " z="1" size="1" public="1" type="0" default="1" />
    public partial class Map {
        [XmlAttribute] public int code;
        [XmlAttribute] public sbyte x;
        [XmlAttribute] public sbyte y;
        [XmlAttribute] public sbyte z;
        [XmlAttribute] public byte size;
        [XmlAttribute] public bool @public;
        [XmlAttribute] public int type;
        [XmlAttribute] public int @default;
    }
}


