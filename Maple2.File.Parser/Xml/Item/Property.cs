using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Item;

public partial class Property {
    [XmlAttribute] public bool skin;
    [XmlAttribute] public int skinType;
    [XmlAttribute] public int slotMax = 1; // if > 99999, set to 99999
    [XmlAttribute] public int type;
    [XmlAttribute] public int subtype;
    [XmlAttribute] public int itemGroup;
    [XmlAttribute] public int collection;
    [XmlAttribute] public int doNotPreview;
    [XmlAttribute] public int doNotSkipRender;
    [XmlAttribute] public int survival;
    [XmlAttribute] public int useSurvival;
    [XmlAttribute] public int applyFatiguePenalty;
    [XmlAttribute] public string category = string.Empty;
    [XmlAttribute] public string blackMarketCategory = string.Empty;
    [XmlAttribute] public int iconCode;
    [XmlAttribute] public int representOption = 35; // if -1 then 35 (real default is -1)
    [XmlAttribute] public string slotIcon = "icon0.png";
    [XmlAttribute] public string slotIconCustom = string.Empty;
    [XmlAttribute] public string movie = string.Empty;
    [XmlAttribute] public string xmlData = string.Empty;
    [XmlAttribute] public string presetPath = string.Empty;
    [XmlAttribute] public bool remakeDisable;
    [XmlAttribute] public int reference;
    [XmlAttribute] public int gearScore;
    [XmlAttribute] public int tradableCount;
    [M2dNullable] public int? globalTradableCount;
    [M2dNullable] public int? globalTradableCountNA;
    [XmlAttribute] public int tradableCountDeduction;
    [M2dNullable] public int? globalTradableCountDeduction;
    [XmlAttribute] public int unlimitedEnchantMaxGrade;
    [XmlAttribute] public int rePackingLimitCount;
    [M2dNullable] public int? globalRePackingLimitCount;
    [XmlAttribute] public int rePackingItemConsumeCount;
    [M2dNullable] public int? globalRePackingItemConsumeCount;
    [M2dArray] public int[] rePackingScrollID = Array.Empty<int>();
    [M2dArray] public int[] globalRePackingScrollID;
    [XmlAttribute] public int socketDataId;
    [XmlAttribute] public string functionTags = string.Empty;
    [XmlAttribute] public bool moveDisable;
    [XmlAttribute] public bool disableDrop;

    [XmlElement] public Sell sell;
    [XmlElement] public Exp exp;

    public partial class Sell {
        [M2dArray] public long[] price = Array.Empty<long>();
        [M2dArray] public long[] priceCustom = Array.Empty<long>();
    }

    public class Exp {
        [XmlAttribute] public long attackExp;
        [XmlAttribute] public long lifeExp;
        [XmlAttribute] public long adventureExp;
    }
}
