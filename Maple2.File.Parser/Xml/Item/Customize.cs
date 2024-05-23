using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Item;

public partial class Customize {
    [XmlAttribute] public int colorPalette;
    [XmlAttribute] public int color;
    [XmlAttribute] public int ch0;
    [XmlAttribute] public int ch1;
    [XmlAttribute] public int ch2;
    [XmlAttribute] public int colordetail;
    [XmlAttribute] public int defaultColorIndex = -1;

    [XmlElement] public Hair HR;
    [XmlElement] public FaceDecal FD;
    [XmlElement] public Cap CP;

    public class Hair {
        [XmlAttribute] public int scale;
        [XmlAttribute] public int pony;
    }

    public class FaceDecal {
        [XmlAttribute] public int translation;
        [XmlAttribute] public int rotation;
        [XmlAttribute] public int scale;
    }

    public class Cap {
        [XmlAttribute] public int xrotation;
        [XmlAttribute] public int yrotation;
        [XmlAttribute] public int zrotation;
        [XmlAttribute] public int scale;
        [XmlAttribute] public int attach;

        [XmlElement] public List<Transform> transform;
    }

    public partial class Transform {
        [M2dVector3] public Vector3 position;
        [M2dVector3] public Vector3 rotation;
        [XmlAttribute] public float scale;
    }
}
