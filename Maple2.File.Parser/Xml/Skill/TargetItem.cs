using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Skill;

public class TargetItem {
    [XmlAttribute] public bool consumeByPetTrap;

    [XmlElement] public List<ConsumeItem> item;
}

public class ConsumeItem {
    [XmlAttribute] public int id;
    [XmlAttribute] public int count;
}
