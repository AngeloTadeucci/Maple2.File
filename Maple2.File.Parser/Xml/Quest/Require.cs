using System;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Quest;

public partial class Require {
    [XmlAttribute] public short level;
    [XmlAttribute] public short maxLevel;
    [XmlAttribute] public int achievement;
    [XmlAttribute] public int achievementGrade;
    [XmlAttribute] public int gearScore;
    [XmlAttribute] public short guildNpcLevel;
    [XmlAttribute] public int dungeon;
    [XmlAttribute] public int unrequireDungeon;
    [XmlAttribute] public int enterDungeon;
    [XmlAttribute] public string alliance = string.Empty;
    [XmlAttribute] public int fameGrade;
    [M2dEnum] public MasteryType masteryType;
    [XmlAttribute] public int masteryGrade;
    [M2dArray] public int[] dungeonBeginner = Array.Empty<int>();
    [XmlAttribute] public int mentor;
    [XmlAttribute] public int mentee;
    [XmlAttribute] public int vip;
    [M2dArray] public int[] equipment = Array.Empty<int>();
    [M2dArray] public int[] subJob = Array.Empty<int>();
    [M2dArray] public int[] progressQuest = Array.Empty<int>();
    [M2dArray] public string[] unreqAchievement = Array.Empty<string>();
    [M2dArray] public int[] quest = Array.Empty<int>();
    [M2dArray] public int[] job = Array.Empty<int>();
    [M2dArray] public int[] unrequire = Array.Empty<int>();
    [M2dArray] public int[] selectableQuest = Array.Empty<int>();
    [M2dArray] public int[] unrequireGroup = Array.Empty<int>();
    [XmlAttribute] public int guildLevel;
    [M2dArray] public Enum.DayOfWeek[] dayOfWeek; // DayOfWeek?
    [XmlAttribute] public int groupID;
}
