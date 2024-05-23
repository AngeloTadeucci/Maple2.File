using System.ComponentModel;
using System.Xml.Serialization;

namespace Maple2.File.IO.Tok.XmlTypes {
    [XmlRoot("mesh3D")]
    public class Mesh3D {
        [XmlAttribute("numberOfStrips"), DefaultValue(0)]
        public short NumberOfStrips;
        [XmlElement("verts")]
        public Vertices Vertices;
        [XmlElement("tris")]
        public Triangles Triangles;
    }
}
