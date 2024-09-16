using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/shop_merat.xml
[XmlRoot("ms2")]
public class ShopMeretRoot {
    [XmlElement] public List<ShopMeret> item;
}

public partial class ShopMeret {
    [XmlAttribute] public int sn;
    [XmlAttribute] public int id;
    [XmlAttribute] public string category = string.Empty;
    [XmlAttribute] public long price;
    [XmlAttribute] public long price_1;
    [XmlAttribute] public long price_7;
    [XmlAttribute] public long price_30;
    [XmlAttribute] public long salePrice;
    [XmlAttribute] public long salePrice_1;
    [XmlAttribute] public long salePrice_7;
    [XmlAttribute] public long salePrice_30;
    [XmlAttribute] public int defPriceIndex;
    [XmlAttribute] public short grade;
    [XmlAttribute] public int saleTag;
    [XmlAttribute] public bool visible;
    [XmlAttribute] public string createDate = string.Empty;
    [XmlAttribute] public int chartOrder;
    [XmlAttribute] public int buyLimit;
    [XmlAttribute] public int buyLimitMax;
}
