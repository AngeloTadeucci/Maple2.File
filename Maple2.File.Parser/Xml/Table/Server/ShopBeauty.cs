using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/NA/shop_beauty.xml
[XmlRoot("ms2")]
public partial class ShopBeautyRoot {
    [XmlElement] public List<ShopBeauty> shop;
}

public partial class ShopBeauty {
    [XmlAttribute] public int shopID;
    [XmlAttribute] public int categoryID;
    [M2dEnum] public PaymentType colorPaymentType;
    [XmlAttribute] public int colorPaymentItemID;
    [XmlAttribute] public string colorPaymentIconTag = string.Empty;
    [XmlAttribute] public int colorPrice;
    [M2dEnum] public PaymentType stylePaymentType;
    [XmlAttribute] public int stylePaymentItemID;
    [XmlAttribute] public string stylePaymentIconTag = string.Empty;
    [XmlAttribute] public int stylePrice;
    [XmlAttribute] public string couponTag = string.Empty;
    [XmlAttribute] public int displayCouponID;
    [XmlAttribute] public int returnCouponID;
    [XmlAttribute] public bool random;
    [XmlAttribute] public bool byItem;
    [M2dFeatureLocale(Selector = "id")] private IList<ShopBeauty.Item> _item;
    [XmlElement] public List<ItemGroup> itemGroup;

    public partial class Item : IFeatureLocale {
        [XmlAttribute] public int id;
        [M2dEnum] public PaymentType paymentType;
        [XmlAttribute] public int paymentItemID;
        [XmlAttribute] public string paymentIconTag = string.Empty;
        [XmlAttribute] public int price;
        [XmlAttribute] public int weight;
        [XmlAttribute] public int achieveID;
        [XmlAttribute] public short achieveGrade;
        [XmlAttribute] public short requireLevel;
        [M2dEnum] public ShopItemFrameType saleTag;
    }

    public partial class ItemGroup {
        [XmlAttribute] public int probVer;
        [XmlAttribute] public string saleStartTime = string.Empty;
        [M2dFeatureLocale(Selector = "id")] private IList<ShopBeauty.Item> _item;
    }
}
