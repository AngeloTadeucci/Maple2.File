using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/enchantOptionTable.xml
[XmlRoot("ms2")]
public class EnchantOptionRoot {
    [XmlElement] public List<EnchantOption> option;
}

public partial class EnchantOption {
    [XmlAttribute] public int id;
    [XmlAttribute] public int slot;
    [XmlAttribute] public int grade;
    [XmlAttribute] public int rank;
    [XmlAttribute] public float rate;
    [XmlAttribute] public int minLv;
    [XmlAttribute] public int maxLv;
    [M2dArray] public int[] option = Array.Empty<int>();
}
