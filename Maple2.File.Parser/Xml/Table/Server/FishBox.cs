using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/globalFishBox.xml
// ./data/server/table/Server/individualFishBox.xml
[XmlRoot("ms2")]
public partial class FishBoxRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<FishBox> _box;
}

public partial class FishBox : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int probability;
    [XmlAttribute] public int cubeRate;
    [XmlElement] public List<Fish> fish;

    public class Fish {
        [XmlAttribute] public int fishCode;
        [XmlAttribute] public int weight;
        [XmlAttribute] public int weightRate;
    }
}
