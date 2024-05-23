using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Skill.Property;

public partial class SplashManualActiveProperty {
    [M2dArray] public int[] splashSkillIDs = Array.Empty<int>();
    [XmlAttribute] public bool onlyManualActiveSplash;
}
