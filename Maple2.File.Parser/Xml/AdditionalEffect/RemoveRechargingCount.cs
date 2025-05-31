using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public partial class RemoveRechargingCount {
    [XmlAttribute] public int skillID;
    [XmlAttribute] public int count;
}
