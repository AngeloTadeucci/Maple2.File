using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Quest;

public class Condition : Common.Condition {
    [XmlElement] public List<Navigation> navi;
}
