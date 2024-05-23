using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Quest;

public class Dispatch {
    [XmlAttribute] public string type = string.Empty; // DispatchType
    [XmlAttribute] public int field;
    [XmlAttribute] public int portal;
    [XmlAttribute] public int script;
}
