using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;
using DayOfWeek = Maple2.File.Parser.Enum.DayOfWeek;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/shop_game.xml
[XmlRoot("ms2")]
public partial class ShopGameRoot {
    [XmlElement] public List<ShopGame> shop;
}

public partial class ShopGame {
    [XmlAttribute] public int shopID;
    [M2dFeatureLocale(Selector = "sn")] private IList<Item> _item;

    public partial class Item : IFeatureLocale {
        [XmlAttribute] public int sn;
        [XmlAttribute] public int id;
        [XmlAttribute] public short grade;
        [M2dEnum] public PaymentType paymentType;
        [XmlAttribute] public bool premiumItem;
        [XmlAttribute] public int paymentItemID;
        [XmlAttribute] public string paymentIconTag = string.Empty;
        [XmlAttribute] public long price;
        [XmlAttribute] public long prob;
        [XmlAttribute] public bool randomOption;
        [XmlAttribute] public string category = string.Empty;
        [XmlAttribute] public bool wearForPreview;
        [XmlAttribute] public int sellCount;
        [XmlAttribute] public int sellUnit;
        [XmlAttribute] public string startDate = string.Empty;
        [XmlAttribute] public string endDate = string.Empty;
        [M2dEnum] public ShopItemFrameType frameType;
        [XmlAttribute] public byte saleTag;
        [XmlAttribute] public string requireAchieve = string.Empty;
        [XmlAttribute] public string requireAlliance = string.Empty;
        [XmlAttribute] public byte requireAllianceGrade;
        [XmlAttribute] public int requireGuildTrophy;
        [M2dArray] public int[] requireChampionshipInfo = Array.Empty<int>();
        [M2dArray] public string[] requireGuildNpc = Array.Empty<string>();
        [XmlAttribute] public bool checkGameEvent;
        [M2dEnum] public DayOfWeek DayOfWeek;
        [XmlAttribute] public string partTime = string.Empty;
        [XmlAttribute] public bool onlyVisibleInPeriod;
    }
}
