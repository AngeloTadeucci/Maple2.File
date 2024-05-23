using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Maple2.File.IO.Tok.XmlTypes {
    [XmlRoot("tris")]
    public class Triangles {
        [XmlElement("tri")]
        public List<Triangle> Triangle;
    }

    [XmlRoot("tri")]
    public class Triangle {
        [XmlAttribute("surfaceType"), DefaultValue(sbyte.MinValue)]
        public sbyte SurfaceType = sbyte.MinValue;
        [XmlAttribute("userData"), DefaultValue(sbyte.MinValue)]
        public sbyte UserData = sbyte.MinValue;

        [XmlAttribute("edge0StartVert")]
        public int Edge0StartVert;
        [XmlAttribute("edge0StartZ"), DefaultValue(short.MinValue)]
        public short Edge0StartZ = short.MinValue;
        [XmlAttribute("edge0Connection"), DefaultValue(int.MinValue)]
        public int Edge0Connection = int.MinValue;

        [XmlAttribute("edge1StartVert")]
        public int Edge1StartVert;
        [XmlAttribute("edge1StartZ"), DefaultValue(short.MinValue)]
        public short Edge1StartZ = short.MinValue; // CStr
        [XmlAttribute("edge1Connection"), DefaultValue(int.MinValue)]
        public int Edge1Connection = int.MinValue;

        [XmlAttribute("edge2StartVert")]
        public int Edge2StartVert;
        [XmlAttribute("edge2StartZ"), DefaultValue(short.MinValue)]
        public short Edge2StartZ = short.MinValue;
        [XmlAttribute("edge2Connection"), DefaultValue(int.MinValue)]
        public int Edge2Connection = int.MinValue;
    }
}
