using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Map;

// Ignored by client.
public class WorldMap {
    [XmlElement] public bool visible;
}
