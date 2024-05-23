using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Quest;

public partial class Guide {
    [M2dEnum] public GuideType guideType = GuideType.unknown;
    [M2dEnum] public GuideGroup guideGroup = GuideGroup.unknown;
    [XmlAttribute] public string guideIcon = string.Empty;
    [XmlAttribute] public short guideMinLevel;
    [XmlAttribute] public short guideMaxLevel;
}
