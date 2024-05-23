using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Maple2.File.IO.Tok.XmlTypes {
    [XmlRoot("verts")]
    public class Vertices {
        [XmlElement("vert")]
        public List<Vertex> Vertex;
    }

    [XmlRoot("vert")]
    public class Vertex {
        [XmlAttribute("x")]
        public int X;
        [XmlAttribute("y")]
        public int Y;
        [XmlAttribute("z")]
        public int Z; // CStr
    }
}
