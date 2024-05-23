using System.Xml.Serialization;
using Maple2.File.Parser.Xml.Common;

namespace Maple2.File.Parser.Xml.Npc;

public class Stat : StatValue {
    [XmlAttribute] public long hiddenhpadd; // Feature 136
    [XmlAttribute] public long hiddennddadd; // Feature 136

    [XmlAttribute] public long hiddenwapadd; // Feature 137

    [XmlAttribute] public long hiddenhpadd03; // Feature 192
    [XmlAttribute] public long hiddennddadd03; // Feature 192
    [XmlAttribute] public long hiddenwapadd03; // Feature 192

    [XmlAttribute] public long hiddenhpadd04; // Feature 262
    [XmlAttribute] public long hiddennddadd04; // Feature 262
    [XmlAttribute] public long hiddenwapadd04; // Feature 262

    [XmlAttribute] public float scaleStatRate_1;
    [XmlAttribute] public float scaleStatRate_2;
    [XmlAttribute] public float scaleStatRate_3;
    [XmlAttribute] public float scaleStatRate_4;
    [XmlAttribute] public long scaleBaseTap_1;
    [XmlAttribute] public long scaleBaseTap_2;
    [XmlAttribute] public long scaleBaseTap_3;
    [XmlAttribute] public long scaleBaseTap_4;
    [XmlAttribute] public long scaleBaseDef_1;
    [XmlAttribute] public long scaleBaseDef_2;
    [XmlAttribute] public long scaleBaseDef_3;
    [XmlAttribute] public long scaleBaseDef_4;
    [XmlAttribute] public float scaleBaseSpaRate_1;
    [XmlAttribute] public float scaleBaseSpaRate_2;
    [XmlAttribute] public float scaleBaseSpaRate_3;
    [XmlAttribute] public float scaleBaseSpaRate_4;
}
