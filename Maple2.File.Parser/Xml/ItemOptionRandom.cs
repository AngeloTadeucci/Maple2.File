// ./data/xml/table/itemoptionconstant.xml
using System.Xml.Serialization;

[XmlRoot("ms2")]
public partial class ItemOptionRandomRootKR {
    [XmlElement("option")] public List<ItemOptionRandomKR> options = [];
}

public partial class ItemOptionRandomKR {
    [XmlAttribute] public int code;
    [XmlAttribute] public int copyID;
    [XmlAttribute] public bool isRarePickOne;
    [XmlAttribute] public int levelGroupID;
    [XmlAttribute] public int pickCount;
    [XmlAttribute] public string statGroup = string.Empty;

    [XmlElement("rank")] public List<ItemOptionRandomDataKR> ranks = [];
}

public partial class ItemOptionRandomDataKR {
    [XmlAttribute] public string name = string.Empty; //additionaleffect_95000012, additionaleffect_95000014, asp, atp, breeding_double_mastery, cad, cap, car, complete_fieldmission_msp, conditionreduce, darkdamage, darkdamagereduce, dex, evp, farming_double_mastery, finaladditionaldamage, firedamage, firedamagereduce, fishing_double_mastery, gathering_double_mastery, heal, hp, icedamage, icedamagereduce, improve_glide_vertical_velocity, improve_massive_crazyrunner_exp, improve_massive_crazyrunner_msp, improve_massive_dancedance_exp, improve_massive_dancedance_msp, improve_massive_escape_exp, improve_massive_escape_msp, improve_massive_finalsurvival_exp, improve_massive_finalsurvival_msp, improve_massive_ox_exp, improve_massive_ox_msp, improve_massive_springbeach_exp, improve_massive_springbeach_msp, improve_massive_trapmaster_exp, improve_massive_trapmaster_msp, int, killhprestore, knockbackreduce, lddincrease, lightdamage, lightdamagereduce, longdistancedamagereduce, luk, map, mar, marpen, mining_double_mastery, msp, nddincrease, neardistancedamagereduce, npc_hit_reward_ep_ball, npc_hit_reward_sp_ball, npckilldropitemincrate, pap, par, parpen, pen, playinstrument_double_mastery, poisondamage, poisondamagereduce, receivedhealincrease, seg_fishingreward, seg_playinstrumentreward, sgi_boss, skillcooldown, smd, str, stunreduce, thunderdamage, thunderdamagereduce,
    [XmlAttribute] public int statID;
}
