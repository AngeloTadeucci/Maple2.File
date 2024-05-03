using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/groupSpawn.xml
[XmlRoot("ms2")]
public class GroupSpawnRoot {
    [XmlElement] public List<GroupSpawn> group;
}

public partial class GroupSpawn {
    [XmlAttribute] public int groupId;
    [XmlElement] public List<Npc> npc;

    public partial class Npc {
        [XmlAttribute] public int id;
        [M2dArray] public string[] tag = Array.Empty<string>();
        [XmlAttribute] public int score;
    }
}
