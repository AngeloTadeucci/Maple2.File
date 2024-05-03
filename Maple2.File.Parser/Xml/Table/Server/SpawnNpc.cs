using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/combineSpawnNpc.xml
[XmlRoot("ms2")]
public partial class SpawnNpcRoot {
    [M2dFeatureLocale(Selector = "combineId")] private IList<SpawnNpc> _spawnNpc;
}

public partial class SpawnNpc : IFeatureLocale {
    [XmlAttribute] public int combineId;
    [XmlAttribute] public int groupId;
    [XmlAttribute] public int weight;
    [XmlAttribute] public int spawnId;
}
