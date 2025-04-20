using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Map;

// ./data/xml/map/%08d.xml
[XmlRoot("ms2")]
public partial class MapDataRoot {
    [M2dFeatureLocale] private MapData _environment;
}

public partial class MapData : IFeatureLocale {
    [XmlElement] public XBlock xblock;
    [XmlElement] public Property property;
    [XmlElement] public Drop drop;
    [XmlElement] public Split split;
    [XmlElement] public CashCall cashCall;
    [XmlElement] public Indoor indoor;
    [XmlElement] public UI ui;
    [XmlElement] public BGM bgm;
    [XmlElement] public HDR hdr;
    [XmlElement] public Survival survival;
    [XmlElement] public Camera camera;
    [XmlElement] public Shadow shadow;
    [XmlElement] public FOV fov;
    [XmlElement] public Optimize optimize;
    [XmlElement] public WorldMap worldmap; // Ignored by client.
}

// .data/xml/table/fielddata.xml
[XmlRoot("ms2")]
public partial class MapDataRootKR {
    // list of fieldData with ID as mapId, then inside its environment as MapDataRoot
    [XmlElement("fieldData")] public List<MapDataRootKR> fieldData;
}

public partial class MapDataRootKR {
    [XmlAttribute] public int id;
    [M2dFeatureLocale] private MapData _environment;
}
