using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Item;

public class Tool {
    [XmlAttribute] public string itemPreset = string.Empty;
    [XmlAttribute] public string itemPresetPath = string.Empty;
}
