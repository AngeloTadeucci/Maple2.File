using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/combineSpawnGroup.xml
[XmlRoot("ms2")]
public partial class SpawnGroupRoot {
    [M2dFeatureLocale(Selector = "groupId")] private IList<SpawnGroup> _groupData;
}

public partial class SpawnGroup : IFeatureLocale {
    [XmlAttribute] public int groupId;
    [XmlAttribute] public string groupType = string.Empty;
    [XmlAttribute] public int combineCount;
    [XmlAttribute] public int resetTick;
    [XmlAttribute] public int fieldId;
}
