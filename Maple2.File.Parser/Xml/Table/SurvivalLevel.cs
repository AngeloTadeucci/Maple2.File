using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/survivallevel.xml
[XmlRoot("ms2")]
public partial class SurvivalLevelRoot {
    [M2dFeatureLocale(Selector = "level")] private IList<SurvivalLevel> _survivalLevelExp;
}

//<survivalLevelExp level="1" reqExp="0" grade="0" feature="SurvivalContents03" />
//<survivalLevelExp level="60" reqExp="113760" grade="7" feature="SurvivalContents03" />
public partial class SurvivalLevel : IFeatureLocale {
    [XmlAttribute] public int level;
    [XmlAttribute] public long reqExp;
    [XmlAttribute] public byte grade;
}
