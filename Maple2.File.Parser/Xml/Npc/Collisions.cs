using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc;

public partial class NodeCollisions {
    [XmlElement] public List<Collision> collision;

    [XmlType(Namespace = "NodeCollisions")]
    public partial class Collision {
        [XmlAttribute] public string targetNode = string.Empty;
        [M2dVector3] public Vector3 volume;
        [M2dVector3] public Vector3 offset;
    }
}

public partial class NodeServerCollisions {
    [XmlElement] public List<Collision> collision;

    [XmlType(Namespace = "NodeServerCollisions")]
    public partial class Collision {
        [M2dVector3] public Vector3 volume;
        [M2dVector3] public Vector3 offset;
    }
}
