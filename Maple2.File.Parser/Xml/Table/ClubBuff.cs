using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/clubbuff.xml
[XmlRoot("ms2")]
public  class ClubBuffRoot {
    [XmlElement] public List<ClubBuff> clubBuff;
}

public partial class ClubBuff {
    [XmlAttribute] public int id;
    [XmlAttribute] public int additionalEffectId;
    [XmlAttribute] public int additionalEffectLevel;
}
