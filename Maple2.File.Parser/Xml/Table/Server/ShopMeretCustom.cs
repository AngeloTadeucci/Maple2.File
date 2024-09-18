using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/shop_merat_custom.xml
[XmlRoot("ms2")]
public class ShopMeretCustomRoot {
    [XmlElement] public List<ShopMeretCustom> item;
}

public partial class ShopMeretCustom {
    [XmlAttribute] public int id;
    [XmlAttribute] public int tabID;
    [XmlAttribute] public string banner = string.Empty;
    [XmlAttribute] public int bannerTag;
    [XmlAttribute] public int itemID;
    [XmlAttribute] public int grade;
    [XmlAttribute] public int quantity;
    [XmlAttribute] public int bonusQuantity;
    [XmlAttribute] public int durationDay;
    [XmlAttribute] public byte saleTag;
    [XmlAttribute] public int paymentType;
    [XmlAttribute] public long price;
    [XmlAttribute] public long salePrice;
    [XmlAttribute] public string saleStartTime = string.Empty;
    [XmlAttribute] public string saleEndTime = string.Empty;
    [M2dArray] public int[] jobRequire = Array.Empty<int>();
    [XmlAttribute] public bool noRestock;
    [XmlAttribute] public short minLevel;
    [XmlAttribute] public short maxLevel;
    [XmlAttribute] public int achieveID;
    [XmlAttribute] public byte achieveGrade;
    [XmlAttribute] public bool pcCafe;
    [XmlAttribute] public bool giftable;
    [XmlAttribute] public bool showSaleTime;
    [XmlAttribute] public string promoName = string.Empty;
    [XmlAttribute] public string promoSaleStartTime = string.Empty;
    [XmlAttribute] public string promoSaleEndTime = string.Empty;
    [XmlElement] public List<ShopMeretCustom> additionalQuantity;
}
