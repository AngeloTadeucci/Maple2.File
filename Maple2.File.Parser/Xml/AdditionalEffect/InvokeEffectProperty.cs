using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public partial class InvokeEffectProperty {
    [XmlAttribute] public int skillID;
    [XmlAttribute] public int skillGroupID;
    [XmlAttribute] public int effectID;
    [XmlAttribute] public int effectGroupID;
    [M2dArray] public int[] types = Array.Empty<int>();
    [M2dArray] public float[] values = Array.Empty<float>();
    [M2dArray] public float[] rates = Array.Empty<float>();
}
