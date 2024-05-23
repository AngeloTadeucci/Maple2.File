using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc;

public partial class Normal {
    [M2dArray] public string[] action = { "Idle_A" };
    [M2dArray] public int[] prob = { 10000 };
    [XmlAttribute] public int movearea = 200;
    [XmlAttribute] public string maidExpired = string.Empty;
}
