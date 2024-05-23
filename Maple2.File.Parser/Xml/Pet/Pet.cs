using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Pet;

// ./data/xml/pet/%08d.xml
[XmlRoot("ms2")]
public class PetDataRoot {
    [XmlElement] public PetData pet;
}

public class PetData {
    [XmlAttribute] public int code;
    [XmlAttribute] public int slotNum;

    [XmlElement] public Skill skill;
    [XmlElement] public Distance distance;
    [XmlElement] public Time time;
}
