using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Xml.Common;

namespace Maple2.File.Parser.Xml;

// ./data/xml/itemoption/constant/itemoptionconstant_%s.xml
[XmlRoot("ms2")]
public partial class ItemOptionConstantRoot {
    [M2dFeatureLocale(Selector = "code|grade")] private IList<ItemOptionConstantData> _option;
}

public partial class ItemOptionConstantData : ItemOption, IFeatureLocale {
    [XmlAttribute] public int code;
    [XmlAttribute] public int grade;

    [XmlAttribute] public float nddcalibrationfactor_rate_base;
    [XmlAttribute] public float wapcalibrationfactor_rate_base;
    [XmlAttribute] public float hpcalibrationfactor_rate_base;
    [XmlAttribute] public long hiddennddadd_value_base;
    [XmlAttribute] public long hiddenwapadd_value_base;
    [XmlAttribute] public long hiddenbapadd_value_base;
    [XmlAttribute] public long hiddenhpadd_value_base;

    [XmlAttribute] public int sgi_target;
}


// ./data/xml/table/itemoptionconstant.xml
[XmlRoot("ms2")]
public partial class ItemOptionConstantRootKR {
    [XmlElement("option")] public List<ItemOptionConstant> options = [];
}

public partial class ItemOptionConstant {
    [XmlAttribute] public int code;

    [XmlElement("rank")] public List<ItemOptionConstantRank> ranks = [];
}

public partial class ItemOptionConstantRank {
    [XmlAttribute] public int grade;
    [XmlAttribute] public int createType;

    [XmlElement("v")] public List<ItemOptionConstantDataKR> options = [];
}

public partial class ItemOptionConstantDataKR {
    [XmlAttribute] public string name = string.Empty; //abp, asp, atp, bap, bap_pet, cad, cap, car, conditionreduce, dex, evp, finaladditionaldamage, firedamage, heal, hp, improve_darkstream_damage, improve_honor_token, improve_pvp_exp, int, lddincrease, longdistancedamagereduce, luk, map, mar, marpen, msp, ndd, nddincrease, neardistancedamagereduce, pap, par, parpen, pen, poisondamage, pvpdamageincrease, pvpdamagereduce, reduce_darkstream_recive_damage, sgi_boss, sgi_elite, skillcooldown, sss, str, stunreduce, thunderdamage, wapmax, wapmin, wapRate,
    [XmlAttribute] public int value;
    [XmlAttribute] public int luaIndex; //??
}
