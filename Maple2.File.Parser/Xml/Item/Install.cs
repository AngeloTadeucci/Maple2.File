using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Item;

public partial class Install {
    [XmlAttribute] public int placeable;
    [XmlAttribute] public int unchangeable;
    [XmlAttribute] public int cannotStackAttach;
    [XmlAttribute] public int stackable;
    [XmlAttribute] public int stackableD;
    [XmlAttribute] public int attachable;
    [XmlAttribute] public int wall;
    [XmlAttribute] public int generatePhysX;
    [XmlAttribute] public int cubeProp;
    [XmlAttribute] public int space;
    [XmlAttribute] public int animatable;
    [XmlAttribute] public int funcCode;
    [XmlAttribute] public int objCode;
    [XmlAttribute] public float staticAngle;
    [XmlAttribute] public int indoor;
    [XmlAttribute] public int bankType;
    [XmlAttribute] public string asset = string.Empty;
    [XmlAttribute] public string preset = string.Empty;
    [XmlAttribute] public string mapAttribute = string.Empty;
    [XmlAttribute] public string propCollisionGroup = string.Empty;
    [XmlAttribute] public bool useInstancing = true;
    [M2dVector3] public Vector3 physXdimension;
}
