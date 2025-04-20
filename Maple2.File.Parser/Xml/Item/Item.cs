using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Item;

// ./data/xml/item/%01d/%02d/%08u.xml
[XmlRoot("ms2")]
public partial class ItemDataRoot {
    [M2dFeatureLocale] private ItemData _environment;
}

public partial class ItemData : IFeatureLocale {
    [XmlElement] public Basic basic;
    [XmlElement] public Slots slots;
    [XmlElement] public Customize customize;
    [XmlElement] public Mutation mutation;
    [XmlElement] public Cutting cutting;
    [XmlElement] public Install install;
    [XmlElement] public Property property;
    [XmlElement] public Material material;
    [XmlElement] public Life life;
    [XmlElement] public Limit limit;
    [XmlElement] public Skill skill;
    [XmlElement] public Skill objectWeaponSkill;
    [XmlElement] public Title title;
    [XmlElement] public Drop drop;
    [XmlElement] public UCC ucc;
    [XmlElement] public Effect effect;
    [XmlElement] public Fusion fusion;
    [XmlElement] public Pet pet;
    [XmlElement] public Ride ride;
    [XmlElement] public Badge gem;
    [XmlElement] public AdditionalEffect AdditionalEffect;
    [XmlElement] public Function function;
    [XmlElement] public Tool tool;
    [XmlElement] public Option option;
    [XmlElement] public Maid maid;
    [XmlElement] public PCBang PCBang;
    [XmlElement] public MusicScore MusicScore;
    [XmlElement] public Housing housing;
    [XmlElement] public Shop Shop;
}

// ./data/xml/itemdata/%03d.xml
[XmlRoot("ms2")]
public partial class ItemDataKR {
    [XmlElement("item")] public List<ItemDataRootKR> items;
}

public partial class ItemDataRootKR {
    [XmlAttribute] public int id;
    [M2dFeatureLocale] private ItemData _environment;
}

public partial class ItemDataKR : IFeatureLocale {
    [XmlElement] public Basic basic;
    [XmlElement] public Slots slots;
    [XmlElement] public Customize customize;
    [XmlElement] public Mutation mutation;
    [XmlElement] public Cutting cutting;
    [XmlElement] public Install install;
    [XmlElement] public Property property;
    [XmlElement] public Material material;
    [XmlElement] public Life life;
    [XmlElement] public Limit limit;
    [XmlElement] public Skill skill;
    [XmlElement] public Skill objectWeaponSkill;
    [XmlElement] public Title title;
    [XmlElement] public Drop drop;
    [XmlElement] public UCC ucc;
    [XmlElement] public Effect effect;
    [XmlElement] public Fusion fusion;
    [XmlElement] public Pet pet;
    [XmlElement] public Ride ride;
    [XmlElement] public Badge gem;
    [XmlElement] public AdditionalEffect AdditionalEffect;
    [XmlElement] public Function function;
    [XmlElement] public Tool tool;
    [XmlElement] public Option option;
    [XmlElement] public Maid maid;
    [XmlElement] public PCBang PCBang;
    [XmlElement] public MusicScore MusicScore;
    [XmlElement] public Housing housing;
    [XmlElement] public Shop Shop;
}
