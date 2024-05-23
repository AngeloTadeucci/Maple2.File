using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Npc;

public class Combat {
    [XmlAttribute] public int combatAbandonTick;
    [XmlAttribute] public int impossibleCombatAbandonTick;
    [XmlAttribute] public bool ignoreExtendLifeTime;
    [XmlAttribute] public bool canShowHideTarget;
}
