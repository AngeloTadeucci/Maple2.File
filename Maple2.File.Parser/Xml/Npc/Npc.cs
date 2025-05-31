using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc;

// ./data/xml/npc/%02d/%08d.xml
[XmlRoot("ms2")]
public partial class NpcDataRoot {
    [M2dFeatureLocale] private NpcData _environment;
    [XmlElement] public List<EffectDummy> effectdummy;
}

public partial class NpcData : IFeatureLocale {
    [XmlElement] public Model model;
    [XmlElement] public Basic basic;
    [XmlElement] public Stat stat;
    [XmlElement] public Speed speed;
    [XmlElement] public Distance distance;
    [XmlElement] public Crystals crystals;
    [XmlElement] public Skill skill;
    [XmlElement] public AdditionalEffect additionalEffect;
    [XmlElement] public Interact interact;
    [XmlElement] public Combat combat; // Ignored by client.
    [XmlElement] public Assist assist;
    [XmlElement] public AiInfo aiInfo;
    [XmlElement] public Collision collision;
    [XmlElement] public NodeCollisions nodeCollisions;
    [XmlElement] public NodeServerCollisions nodeServerCollisions;
    [XmlElement] public Capsule capsule;
    [XmlElement] public ValidBattleCylinder validBattleCylinder;
    [XmlElement] public Dead dead;
    [XmlElement] public Push push;
    [XmlElement] public Exp exp;
    [XmlElement] public Shadow shadow;
    [XmlElement] public Normal normal;
    [XmlElement] public DropItemInfo dropiteminfo;
    [XmlElement] public LookAtTarget lookattarget;
    [XmlElement] public Corpse corpse;
    [XmlElement] public Ride ride; // Ignored by client.
}

[XmlRoot("ms2")]
public partial class NpcDataListNew {
    [XmlElement("npc")] public List<NpcDataRootNew> npcs;
}

public partial class NpcDataRootNew {
    [XmlAttribute] public int id;
    [XmlElement] public NpcDataNew environment;
}

public partial class NpcDataNew : NpcData {
    [XmlElement] public List<EffectDummy> effectdummy;
}
