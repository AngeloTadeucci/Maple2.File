using System.Collections.Generic;
using System.Numerics;
using System;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Item;

public class Slots {
    [XmlElement] public List<Slot> slot;
}

public partial class Slot {
    [XmlAttribute] public string name = string.Empty;

    [XmlElement] public List<Asset> asset;
    [XmlElement] public List<Scale> scale;
    [XmlElement] public Decal decal;

    public class Asset {
        [XmlAttribute] public string name = string.Empty;
        [XmlAttribute] public string selfnode = string.Empty;
        [XmlAttribute] public string targetnode = string.Empty;
        [XmlAttribute] public string attachnode = string.Empty;
        [XmlAttribute] public int pony;
        [XmlAttribute] public int zalign;
        [XmlAttribute] public int replace;
        [XmlAttribute] public int earfold;
        [XmlAttribute] public int ani;
        [XmlAttribute] public int emotionhide;
        [XmlAttribute] public int gender;
        [XmlAttribute] public float capscale;
        [XmlAttribute] public float mantlescale;
        [XmlAttribute] public int weapon;
        [XmlAttribute] public int placeable;

        [XmlElement] public List<Custom> custom;
        [XmlElement] public List<UserRotation> userrotation;
        [XmlElement] public List<JointAngle> jointangle;
        [XmlElement] public List<Dummy> dummy;
        [XmlElement] public PhysX physx;
    }

    public partial class Scale {
        [M2dArray] public float[] value = Array.Empty<float>();
        [XmlAttribute] public float min;
        [XmlAttribute] public float max;
        [XmlAttribute] public int reverse;
    }

    public class Decal {
        [XmlAttribute] public string texture = string.Empty;
        [XmlAttribute] public string controlTexture = string.Empty;

        [XmlElement] public List<Custom> custom;
    }

    public partial class Custom {
        [XmlAttribute] public string icon = string.Empty;
        [M2dVector3] public Vector3 position;
        [M2dVector3] public Vector3 rotation;
    }

    public partial class UserRotation {
        [XmlAttribute] public string axis = string.Empty;
        [XmlAttribute] public float min;
        [XmlAttribute] public float max;
        [M2dArray] public float[] @default = Array.Empty<float>();
    }

    public class JointAngle {
        [XmlAttribute] public string name = string.Empty;
        [XmlAttribute] public float soft;
        [XmlAttribute] public float posz;
        [XmlAttribute] public float zero;
        [XmlAttribute] public float negz;
    }

    public partial class Dummy {
        [XmlAttribute] public int gender;
        [XmlAttribute] public string sequence = string.Empty;
        [XmlAttribute] public string targetnode = string.Empty;
        [XmlAttribute] public bool worldmode;
        [XmlAttribute] public bool worldlerp;
        [XmlAttribute] public float step;
        [M2dVector3] public Vector3 rotation;
        [M2dVector3] public Vector3 translation;
    }

    public partial class PhysX {
        [M2dArray] public string[] action = Array.Empty<string>();
    }
}
