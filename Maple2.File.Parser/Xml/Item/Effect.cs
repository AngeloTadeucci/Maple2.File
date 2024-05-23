using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Item;

public class Effect {
    [XmlAttribute] public int enchantShape = 1;
    [XmlAttribute] public string idle = string.Empty;
    [XmlAttribute] public string battleIdle = string.Empty;
    [XmlAttribute] public string characterIdle = string.Empty;
    [XmlAttribute] public string characterBattleIdle = string.Empty;
}
