using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AI;

public class AiPreset {
    [XmlAttribute] public string name = string.Empty;

    [XmlElement] public List<Node> node;
    [XmlElement] public List<AiPreset> aiPreset;
}
