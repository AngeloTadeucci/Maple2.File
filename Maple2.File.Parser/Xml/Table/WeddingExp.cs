using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/weddingexp.xml
[XmlRoot("ms2")]
public class WeddingExpRoot {
    [XmlElement] public List<WeddingExp> v;
}

public class WeddingExp {
    [XmlAttribute] public int grade;
    [XmlAttribute] public int value;
}
