using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/combineSpawnInteractObject.xml
[XmlRoot("ms2")]
public partial class SpawnInteractObjectRoot {
    [M2dFeatureLocale(Selector = "combineId")] private IList<SpawnInteractObject> _spawnInteractObject;
}

public partial class SpawnInteractObject : IFeatureLocale {
    [XmlAttribute] public int combineId;
    [XmlAttribute] public int groupId;
    [XmlAttribute] public int weight;
    [XmlAttribute] public int regionSpawnId;
    [XmlAttribute] public int interactId;
    [XmlAttribute] public string model = string.Empty;
    [XmlAttribute] public string asset = string.Empty;
    [XmlAttribute] public string normal = string.Empty;
    [XmlAttribute] public string reactable = string.Empty;
    [XmlAttribute] public float scale;
}
