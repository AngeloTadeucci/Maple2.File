using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.MusicScore;

// ./data/xml/musicscore/%08d.xml
[XmlRoot("ms2")]
public class MusicScoreData {
    [XmlElement] public List<Harmony> harmony;

    public class Harmony {
        [XmlAttribute] public string chord = string.Empty;
    }
}
