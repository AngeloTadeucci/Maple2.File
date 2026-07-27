using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc;

public partial class AiInfo {
    [XmlAttribute] public string path = string.Empty;
    [M2dArray] public int[] summonNpcIDs = [];
}
