using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.MapXBlock;

// ./data/resource/exported/xblock/%08d.xblock
[XmlRoot("game")]
public class GameXBlock {
    [XmlElement] public EntitySet entitySet;
}

public class EntitySet {
    [XmlElement] public List<Entity> entity;
}

public class Entity {
    [XmlAttribute] public string id = string.Empty;
    [XmlAttribute] public string modelName = string.Empty;
    [XmlAttribute] public string name = string.Empty;
    [XmlAttribute] public int iterations;

    [XmlElement] public List<Property> property;

    public class Property {
        [XmlAttribute] public string name = string.Empty;

        [XmlElement] public List<Set> set;
    }

    public class Set {
        [XmlAttribute] public string index = string.Empty;
        [XmlAttribute] public string value = string.Empty;
    }
}
