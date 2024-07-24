using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;
using DayOfWeek = Maple2.File.Parser.Enum.DayOfWeek;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/UnlimitedEnchantOption.xml
[XmlRoot("ms2")]
public partial class UnlimitedEnchantOptionRoot {
    [M2dFeatureLocale(Selector = "slot|grade")] private IList<UnlimitedEnchantOption> _option;
}

public partial class UnlimitedEnchantOption : IFeatureLocale {
    [XmlAttribute] public int slot;
    [M2dArray(Delimiter = '-')] public int[] grade = Array.Empty<int>();
    [XmlAttribute] public int option1;
    [XmlAttribute] public float rate1;
    [XmlAttribute] public int value1;
    [XmlAttribute] public int option2;
    [XmlAttribute] public float rate2;
    [XmlAttribute] public int value2;
    [XmlAttribute] public int option3;
    [XmlAttribute] public float rate3;
    [XmlAttribute] public int value3;
    [XmlAttribute] public int option4;
    [XmlAttribute] public float rate4;
    [XmlAttribute] public int value4;
    [XmlAttribute] public int sa_option1;
    [XmlAttribute] public float sa_rate1;
    [XmlAttribute] public int sa_value1;
    [XmlAttribute] public int sa_option2;
    [XmlAttribute] public float sa_rate2;
    [XmlAttribute] public int sa_value2;
}
