using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/shop_game_info.xml
[XmlRoot("ms2")]
public partial class ShopGameInfoRoot {
    [M2dFeatureLocale(Selector = "shopID")] private IList<ShopGameInfo> _shop;
}

public partial class ShopGameInfo : IFeatureLocale {
    [XmlAttribute] public int shopID;
    [XmlAttribute] public int categoryID;
    [XmlAttribute] public int meratItemGroupID;
    [XmlAttribute] public string iconName = string.Empty;
    [XmlAttribute] public bool showOnlyUsableItem;
    [XmlAttribute] public bool showProbInfo;
    [XmlAttribute] public bool isOpenTokenPocket;
    [XmlAttribute] public bool hideOptionInfo;
    [XmlAttribute] public bool isOnlySell;
    [XmlAttribute] public int shopVersion;
    [XmlAttribute] public bool resetEnable;
    [XmlAttribute] public int resetPrice;
    [XmlAttribute] public int resetListMax;
    [XmlAttribute] public int resetListMin;
    [XmlAttribute] public int resetType;
    [XmlAttribute] public bool resetByAccount;
    [XmlAttribute] public bool resetButtonHide;
    [XmlAttribute] public string resetFixedTime = string.Empty;
    [XmlAttribute] public int resetIntervalTime;
    [XmlAttribute] public int resetPaymentType;
    [XmlAttribute] public bool useLuaResetPayment;
    [XmlAttribute] public bool useLuaPremiumItemRandomCount;
    [XmlAttribute] public bool disableDisplayOrderSort;
    [XmlAttribute] public bool isSmartShopItemList;
    [M2dEnum] public ShopUiFrameType uiFrameType;
}
