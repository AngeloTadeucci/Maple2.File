using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/shop_ugcall.xml
// ./data/xml/table/na/shop_maid.xml
[XmlRoot("ms2")]
public partial class ShopFurnishingRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<ShopFurnishing> _key;
}

public partial class ShopFurnishing : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public bool ugcHousingBuy;
    [M2dEnum] public HousingMoneyType ugcHousingMoneyType = HousingMoneyType.Meso;
    [XmlAttribute] public int ugcHousingDefaultPrice;
}

public enum HousingMoneyType {
    Meso = 1,
    Meret = 3,
}
