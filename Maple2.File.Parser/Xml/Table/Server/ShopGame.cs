using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/shop_game.xml
[XmlRoot("ms2")]
public partial class ShopGameRoot {
    [XmlElement] public List<ShopGame> shop;
}

public partial class ShopGame {
    [XmlAttribute] public int shopID;
    [M2dFeatureLocale(Selector = "sn")] private IList<ShopGame.Item> _item;

    public partial class Item : IFeatureLocale {
        [XmlAttribute] public int sn;
        [XmlAttribute] public int id;
        [XmlAttribute] public short grade;
        [M2dEnum] public PaymentType paymentType;
        [XmlAttribute] public bool premiumItem;
        [XmlAttribute] public int paymentItemID;
        [XmlAttribute] public string paymentIconTag;
        [XmlAttribute] public long price;
        [XmlAttribute] public long prob;
        [XmlAttribute] public bool randomOption;
        [XmlAttribute] public string category;
        [XmlAttribute] public bool wearForPreview;
        [XmlAttribute] public int sellCount;
        [XmlAttribute] public int sellUnit;
        [XmlAttribute] public string startDate;
        [XmlAttribute] public string endDate;
        [M2dEnum] public ShopItemFrameType frameType;
        [XmlAttribute] public byte saleTag;
        [XmlAttribute] public string requireAchieve;
        [XmlAttribute] public string requireAlliance;
        [XmlAttribute] public byte requireAllianceGrade;
        [M2dArray] public int[] requireChampionshipInfo;
        [M2dArray] public string[] requireGuildNpc;
    }
}
