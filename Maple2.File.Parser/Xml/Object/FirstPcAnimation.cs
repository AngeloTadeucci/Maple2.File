using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Object;

public partial class FirstPcAnimation {
    [XmlAttribute] public string firstAnimation = string.Empty;
    [XmlAttribute] public string reactableEffect = string.Empty;
    [XmlAttribute] public string firstPCBone = string.Empty;
    [XmlAttribute] public int firstUsePCMove;
    [M2dVector3] public Vector3 firstPCTranslation;
    [M2dVector3] public Vector3 firstPCRotation = Vector3.UnitX;
    [XmlAttribute] public string firstEmotionID = string.Empty;
    [XmlAttribute] public string firstEffectStart = string.Empty;
    [XmlAttribute] public string firstEffectEnd = string.Empty;
}
