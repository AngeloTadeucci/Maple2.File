using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/charactercreateselect.xml
[XmlRoot("ms2")]
public partial class CharacterCreateSelect {
    [M2dFeatureLocale(Selector = "name")] private IList<CharacterCreateSelectGroup> _group;
}

public partial class CharacterCreateSelectGroup : IFeatureLocale {
    [XmlAttribute] public string name = string.Empty;
    [M2dFeatureLocale(Selector = "jobCode")] private IList<CharacterCreateSelectList> _list;
}

public partial class CharacterCreateSelectList : IFeatureLocale {
    [XmlAttribute] public int jobCode;
    [XmlAttribute] public string movie = string.Empty;
    [XmlAttribute] public int descKey;

    [M2dArray] public int[] order = Array.Empty<int>();
    [M2dArray] public int[] disableJobCode = Array.Empty<int>();
    [M2dArray] public int[] selectJobCode = Array.Empty<int>();
    [M2dArray] public int[] randomselectJobCode = Array.Empty<int>();
}
