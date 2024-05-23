using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/masterydifferentialfactor.xml
[XmlRoot("ms2")]
public class MasteryDifferentialFactorRoot {
    [XmlElement] public List<MasteryDifferentialFactor> v;
}

public class MasteryDifferentialFactor {
    [XmlAttribute] public int differential;
    [XmlAttribute] public int factor;
    [XmlAttribute] public string icon = string.Empty;
}
