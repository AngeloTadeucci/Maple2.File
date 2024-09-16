using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/weddingpackage.xml
[XmlRoot("ms2")]
public partial class WeddingPackageRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<WeddingPackage> _package;
}

public partial class WeddingPackage : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int planner;
    [XmlElement] public List<WeddingHall> weddingHall;
}

public class WeddingHall {
    [XmlAttribute] public int id;
    [XmlAttribute] public int fieldID;
    [XmlAttribute] public int nightFieldID;
    [XmlAttribute] public byte grade;
    [XmlAttribute] public int merat;
    [XmlAttribute] public string videoPath = string.Empty;
    [XmlAttribute] public string desc = string.Empty;
    [XmlAttribute] public string mcillust = string.Empty;
    [XmlElement] public List<WeddingItem> weddingItem;
    [XmlElement] public List<WeddingItem> weddingCompleteItem;
}

public class WeddingItem {
    [XmlAttribute] public int itemID;
    [XmlAttribute] public byte grade;
    [XmlAttribute] public int count;
    [XmlAttribute] public bool nightReward;
}
