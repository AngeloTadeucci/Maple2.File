using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Item;

public class Cutting {
    [XmlElement] public List<Mesh> mesh;

    public class Mesh {
        [XmlAttribute] public string name = string.Empty;
        [XmlAttribute] public int gender;
    }
}
