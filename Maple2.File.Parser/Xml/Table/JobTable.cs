using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/job.xml
[XmlRoot("ms2")]
public partial class JobRoot {
    [M2dFeatureLocale(Selector = "code")] private IList<JobTable> _job;
}

public partial class JobTable : IFeatureLocale {
    [XmlAttribute] public int code = 1;
    [XmlAttribute] public int characterBGM;
    [M2dArray] public string[] defaultWeaponSlot = Array.Empty<string>();
    [M2dArray] public int[] tutorialSkipField = Array.Empty<int>();
    [XmlAttribute] public int tutorialSkipItem;
    [XmlAttribute] public int tutorialSaveID = -1;
    [M2dArray] public int[] tutorialClearOpenMaps = Array.Empty<int>();
    [M2dArray] public int[] tutorialClearOpenTaxis = Array.Empty<int>();
    [XmlAttribute] public int startField; // default = 524289?

    [M2dFeatureLocale] private CharacterVoice _characterVoice;
    [XmlElement] public JobItem startInvenItem;
    [XmlElement] public JobItem reward;
    [XmlElement] public Skills skills;
    [XmlElement] public List<Learn> learn;
}

public partial class CharacterVoice : IFeatureLocale {
    [XmlAttribute] public string value;
}

public partial class JobItem {
    [M2dFeatureLocale] private IList<Item> _item;

    public partial class Item : IFeatureLocale {
        [XmlAttribute] public int itemID;
        [XmlAttribute] public int grade;
        [XmlAttribute] public int count = 1;
        [XmlAttribute] public string slotHint = string.Empty;
    }
}

public partial class Skills {
    [M2dFeatureLocale(Selector = "main")] private IList<Skill> _skill;

    public partial class Skill : IFeatureLocale {
        [XmlAttribute] public int main;
        [M2dArray] public int[] sub = Array.Empty<int>();
        [XmlAttribute] public int subJobCode;
        [XmlAttribute] public short maxLevel = 1;
        [XmlAttribute] public int quickSlotPriority;
        [M2dArray] public int[] uiPosition = Array.Empty<int>();
        [XmlAttribute] public bool uiHighlight;
    }
}

public partial class Learn {
    [XmlAttribute] public short level;

    [M2dFeatureLocale(Selector = "id")] private IList<LearnSkill> _skill;

    public partial class LearnSkill : IFeatureLocale {
        [XmlAttribute] public int id;
        [M2dArray] public int[] sub = Array.Empty<int>();
    }
}


[XmlRoot("ms2")]
public partial class JobRootKR {
    [M2dFeatureLocale(Selector = "jobGroupID")] private IList<JobTableKR> _job;
}

public partial class JobTableKR : IFeatureLocale {
    [XmlAttribute] public int jobGroupID = 1;
    [XmlAttribute] public int subJob1 = 1;
    [XmlAttribute] public int subJob2 = 1;
    [XmlAttribute] public int characterBGM;
    [XmlAttribute] public int defaultWeaponSlot;
    [XmlAttribute] public int startField; // default = 524289?
    [XmlAttribute] public string characterVoice = string.Empty;

    [M2dArray] public int[] startItems = Array.Empty<int>();

    [XmlElement("skills")] public SkillsKR skills;
}

public partial class SkillsKR {
    [XmlElement("v")] public List<Skill> skills;

    public partial class Skill : IFeatureLocale {
        [XmlAttribute] public int skillID;
        [M2dArray] public int[] subSkillIDs = Array.Empty<int>();
        [XmlAttribute] public int jobLevel;
        [XmlAttribute] public short maxLevel = 1;
        [XmlAttribute] public int quickSlotPriority;
        [M2dArray] public int[] uiPosition = Array.Empty<int>();
        [XmlAttribute] public bool uiHighlight;
        [M2dArray] public int[] requireLevel = Array.Empty<int>();
        [M2dArray] public int[] requireSkillIDs = Array.Empty<int>();
        [M2dArray] public int[] requireSkillLevels = Array.Empty<int>();
        [XmlAttribute] public int requireQuestID;
    }
}
