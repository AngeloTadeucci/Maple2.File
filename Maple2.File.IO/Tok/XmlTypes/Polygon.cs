using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Maple2.File.IO.Tok.XmlTypes {
    [XmlRoot("poly")]
    public class Polygon {
        [XmlElement("edge")]
        public List<Edge> Edges;
    }

    [XmlRoot("edge")]
    public class Edge {
        [XmlAttribute("startVert")]
        public int StartVert;
        [XmlAttribute("connection"), DefaultValue(short.MinValue)]
        public short Connection = short.MinValue;
    }
}
