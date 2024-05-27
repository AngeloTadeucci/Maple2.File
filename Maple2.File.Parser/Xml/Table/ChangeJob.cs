using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/changejob.xml
[XmlRoot("ms2")]
public partial class ChangeJobRoot {
    [M2dFeatureLocale(Selector = "subJobCode")] private IList<ChangeJob> _subjob;
}

public partial class ChangeJob : IFeatureLocale {
    [XmlAttribute] public int subJobCode;
    [XmlAttribute] public int changeSubJobCode;
    [XmlAttribute] public string movie = string.Empty;
    [XmlAttribute] public int desc;
    [XmlAttribute] public int skilldesc1;
    [M2dArray] public int[] skillID1 = Array.Empty<int>();
    [XmlAttribute] public int skilldesc2;
    [M2dArray] public int[] skillID2 = Array.Empty<int>();
    [XmlAttribute] public int startquestid;
    [XmlAttribute] public int endquestid;
}
