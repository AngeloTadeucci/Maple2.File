using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/maplesurvivalskininfo.xml
[XmlRoot("ms2")]
public partial class MapleSurvivalSkinInfoRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<MapleSurvivalSkinInfo> _skinInfo;
}

public partial class MapleSurvivalSkinInfo : IFeatureLocale {
    [XmlAttribute] public int id;
    [M2dEnum] public SurvivalSkinType type;
    [XmlAttribute] public string imagePath = string.Empty;
    [XmlAttribute] public string mainImagePath = string.Empty;
    [XmlAttribute] public int value1;
    [XmlAttribute] public int value2;
}
