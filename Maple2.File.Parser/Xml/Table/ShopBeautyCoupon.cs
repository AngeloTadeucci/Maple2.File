using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/shop_beautycoupon.xml
[XmlRoot("ms2")]
public partial class ShopBeautyCouponRoot {
    [XmlElement] public List<ShopBeautyCoupon> shop;
}

public partial class ShopBeautyCoupon {
    [XmlAttribute] public int shopID;
    [XmlAttribute] public byte byItem;
    [M2dFeatureLocale(Selector = "id")] private IList<Item> _item;

    public partial class Item : IFeatureLocale {
        [XmlAttribute] public int id;
    }
}
