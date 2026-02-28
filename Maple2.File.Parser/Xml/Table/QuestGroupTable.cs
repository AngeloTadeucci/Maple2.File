using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/questgrouptable.xml
[XmlRoot("ms2")]
public class QuestGroupRoot {
    [XmlElement] public List<QuestGroup> group;
}

public class QuestGroup {
    [XmlAttribute] public int id;
    [XmlAttribute] public int pickCount;
    [XmlAttribute] public string dependency;
}
