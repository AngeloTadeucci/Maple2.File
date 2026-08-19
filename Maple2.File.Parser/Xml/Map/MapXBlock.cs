using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Map;

// ./data/xml/mapxblock/<xblockname>.xml
[XmlRoot("ms2")]
public class MapXBlockDataRoot {
    [XmlElement] public ClientProperty clientProperty;
    [XmlElement] public Minimap minimap;
    [XmlElement] public Fog fog;
    [XmlElement] public HeightFog heightfog;
}

public class ClientProperty {
    [XmlAttribute] public string bgDay = string.Empty;
    [XmlAttribute] public string bgNight = string.Empty;
}

public partial class Minimap {
    [XmlElement] public Image image;
    [XmlElement] public Frustum frustum;
    [XmlElement] public Screen screen;
    [XmlElement] public Camera camera;
    [XmlElement] public Edit edit;

    public class Image {
        [XmlAttribute] public string name = string.Empty;
        [XmlAttribute] public float left;
        [XmlAttribute] public float right;
        [XmlAttribute] public float top;
        [XmlAttribute] public float bottom;
        [XmlAttribute] public string icon = string.Empty;
    }

    public class Frustum {
        [XmlAttribute] public float left;
        [XmlAttribute] public float right;
        [XmlAttribute] public float top;
        [XmlAttribute] public float bottom;
        [XmlAttribute] public float near;
        [XmlAttribute] public float far;
        [XmlAttribute] public bool ortho;
    }

    public class Screen {
        [XmlAttribute] public float left;
        [XmlAttribute] public float right;
        [XmlAttribute] public float top;
        [XmlAttribute] public float bottom;
    }

    public partial class Camera {
        [M2dVector3] public Vector3 position;
        [M2dVector3] public Vector3 rotation;
    }

    public class Edit {
        [XmlAttribute] public float zoomfactor;
    }
}

public partial class Fog {
    [XmlAttribute] public string color = string.Empty;
    [XmlAttribute] public float near;
    [XmlAttribute] public float far;
}

public partial class HeightFog {
    [XmlAttribute] public string color = string.Empty;
    [XmlAttribute] public float upper;
    [XmlAttribute] public float lower;
    [XmlAttribute] public float percentage;
}
