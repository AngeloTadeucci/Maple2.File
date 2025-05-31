using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Xml.AdditionalEffect;

namespace Maple2.File.Parser.Xml.Skill;

public partial class Basic : IFeatureLocale {
    [XmlElement] public UI ui;
    [XmlElement] public Kinds kinds;
    [XmlElement] public StateAttribute stateAttr;
}

public partial class BasicNew : IFeatureLocale {
    [XmlAttribute] public int mainType;
    [XmlAttribute] public string paramStr = string.Empty;
    [XmlAttribute] public int param1;
    [XmlElement] public UI ui;
    [XmlElement] public KindsNew kinds;
    [XmlElement] public ComboNew combo;
    [XmlElement] public ChangeSkillNew changeSkill;
    [XmlElement] public AutoTargeting autoTargeting;
    [XmlElement] public Push push;
    [XmlElement] public StateAttributeNew stateAttr;
    [XmlElement] public Sensor sensor;
    [XmlElement] public MagicControlNew magicControl;
    [XmlElement] public Condition condition;
}
