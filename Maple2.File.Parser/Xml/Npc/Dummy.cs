﻿using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc;

public class EffectDummy {
    [XmlElement] public List<Dummy> dummy = [];
}

public partial class Dummy {
    [XmlAttribute] public string name = string.Empty;

    [XmlElement] public AttachInfo attachInfo = new();
    [XmlElement] public Transform transform = new();

    public class AttachInfo {
        [XmlAttribute] public string parentNode = string.Empty;
        [XmlAttribute] public bool applyWorldTransform;
        [XmlAttribute] public bool applyLocalScale;
    }

    public partial class Transform {
        [M2dVector3] public Vector3 translate = default;
        [M2dVector3] public Vector3 rotation = default;
        [XmlAttribute] public float scale;
    }
}
