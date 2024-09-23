using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/itemOptionProbability.xml
[XmlRoot("ms2")]
public class ItemOptionProbabilityRoot {
    [XmlElement] public List<ItemOptionProbability> option;
}

public partial class ItemOptionProbability {
    [XmlAttribute] public string name = string.Empty;
    [XmlAttribute] public int weaponProbability;
    [XmlAttribute] public int armorProbability;
    [XmlAttribute] public int accProbability;
    [XmlAttribute] public int petProbability;
}
