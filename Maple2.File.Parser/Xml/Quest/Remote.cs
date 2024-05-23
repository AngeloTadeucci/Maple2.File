using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Quest;

public partial class Remote {
    [M2dEnum] public UseRemoteType useRemote = UseRemoteType.unknown;
    [XmlAttribute] public int requireField;
    [XmlAttribute] public int requireDungeonClear;
}
