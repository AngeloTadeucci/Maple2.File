using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Common;

[XmlType(Namespace = "Common")]
public partial class Condition {
    [M2dEnum] public ConditionType type = ConditionType.unknown;
    [XmlAttribute] public long value = 1;
    [M2dArray] public string[] code = Array.Empty<string>(); // split on ',' and '-'
    [M2dArray] public string[] target = Array.Empty<string>(); // split on ',' and ':'
    [XmlAttribute] public int partyCount;
    [XmlAttribute] public int guildPartyCount;
}
