using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/guildbuff.xml
[XmlRoot("ms2")]
public partial class GuildBuffRoot {
    [M2dFeatureLocale(Selector = "id|level")] private IList<GuildBuff> _guildBuff;
}

public partial class GuildBuff : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public short level;
    [XmlAttribute] public int additionalEffectId;
    [XmlAttribute] public short additionalEffectLevel;
    [XmlAttribute] public short requireLevel;
    [XmlAttribute] public int upgradeCost;
    [XmlAttribute] public int cost;
    [XmlAttribute] public int duration;
    [XmlAttribute] public int cooltime;
    [XmlAttribute] public byte type;
    [XmlAttribute] public string functionName = string.Empty;
}
