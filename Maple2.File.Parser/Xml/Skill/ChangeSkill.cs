﻿using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Skill; 

public partial class ChangeSkill {
    [M2dArray] public int[] changeSkillCheckEffectID = Array.Empty<int>();
    [M2dArray] public int[] changeSkillCheckEffectLevel = Array.Empty<int>();
    [M2dArray] public int[] changeSkillCheckEffectOverlapCount = Array.Empty<int>();
    [M2dArray] public int[] changeSkillID = Array.Empty<int>();
    [M2dArray] public int[] changeSkillLevel = Array.Empty<int>();
    [XmlAttribute] public int originSkillID;
    [XmlAttribute] public short originSkillLevel = 1;
    [XmlAttribute] public int autoChange;
}