using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/blackmarkettable.xml
[XmlRoot("ms2")]
public partial class BlackMarketRoot {
    [XmlElement] public List<BlackMarketStatTable> stat_table;
    [XmlElement] public BlackMarketOption option;
    [XmlElement] public BlackMarketCategory category;
}

public class BlackMarketStatTable {
    [XmlAttribute] public int id;
    [XmlElement] public List<Stat> stat;

    public class Stat {
        [XmlAttribute] public string name = string.Empty;
        [XmlAttribute] public bool percent;
        [XmlAttribute] public float @default;
    }
}

public partial class BlackMarketOption {
    [XmlAttribute] public int id;
    [M2dArray] public int[] stat_tables = Array.Empty<int>();
}

public partial class BlackMarketCategory {
    [XmlAttribute] public int id;
    [M2dFeatureLocale] private IList<BlackMarketTab> _tab;

    public partial class BlackMarketTab : IFeatureLocale {
        [XmlAttribute] public string name = string.Empty;
        [XmlAttribute] public int id;
        [XmlAttribute] public int priority;
        [M2dArray] public string[] category = Array.Empty<string>();
        [XmlAttribute] public int option_id;
        [XmlAttribute] public bool auto_complete_name;
        [XmlAttribute] public bool showIncludeLowTab;
        [M2dFeatureLocale] private IList<BlackMarketTab> _tab;
    }
}
