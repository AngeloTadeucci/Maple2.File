using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Skill;

public partial class Combo {
    [XmlAttribute] public int comboSkill;
    [XmlAttribute] public int chargingSkill;
    [XmlAttribute] public int comboOriginSkill;
    [XmlAttribute] public int npcComboSkillID;
    [XmlAttribute] public short npcComboSkillLevel = 1;
    [XmlAttribute] public bool disableChargingAttackSkipFrame;
    [M2dArray] public int[] inputSkill = Array.Empty<int>();
    [M2dArray] public int[] outputSkill = Array.Empty<int>();
}

public partial class ComboNew {
    [XmlAttribute] public int comboSkill;
    [XmlAttribute] public int chargingSkill;
    // [XmlAttribute] public int comboOriginSkill;
    // [XmlAttribute] public int npcComboSkillID;
    // [XmlAttribute] public short npcComboSkillLevel = 1;
    [XmlAttribute] public bool disableChargingAttackSkipFrame;
    [M2dArray] public int[] inputSkill = Array.Empty<int>();
    [M2dArray] public int[] outputSkill = Array.Empty<int>();
}
