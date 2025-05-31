using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Common;

[XmlType(Namespace = "Common")]
public class ItemOptionNew {
    #region StatValue
    [XmlAttribute("str")] public int str_value_base;
    [XmlAttribute("dex")] public int dex_value_base;
    [XmlAttribute("int")] public int int_value_base;
    [XmlAttribute("luk")] public int luk_value_base;
    [XmlAttribute("hp")] public int hp_value_base;
    [XmlAttribute("hp_rgp")] public int hp_rgp_value_base;
    [XmlAttribute("hp_inv")] public int hp_inv_value_base;
    [XmlAttribute("sp")] public int sp_value_base;
    [XmlAttribute("sp_rgp")] public int sp_rgp_value_base;
    [XmlAttribute("sp_inv")] public int sp_inv_value_base;
    [XmlAttribute("ep")] public int ep_value_base;
    [XmlAttribute("ep_rgp")] public int ep_rgp_value_base;
    [XmlAttribute("ep_inv")] public int ep_inv_value_base;
    [XmlAttribute("asp")] public int asp_value_base;
    [XmlAttribute("msp")] public int msp_value_base;
    [XmlAttribute("atp")] public int atp_value_base;
    [XmlAttribute("evp")] public int evp_value_base;
    [XmlAttribute("cap")] public int cap_value_base;
    [XmlAttribute("cad")] public int cad_value_base;
    [XmlAttribute("car")] public int car_value_base;
    [XmlAttribute("ndd")] public int ndd_value_base;
    [XmlAttribute("pap")] public int pap_value_base;
    [XmlAttribute("map")] public int map_value_base;
    [XmlAttribute("par")] public int par_value_base;
    [XmlAttribute("mar")] public int mar_value_base;
    [XmlAttribute("wapmin")] public int wapmin_value_base;
    [XmlAttribute("wapmax")] public int wapmax_value_base;
    [XmlAttribute("dmg")] public int dmg_value_base;
    [XmlAttribute("rmsp")] public int rmsp_value_base;
    [XmlAttribute("bap")] public int bap_value_base;
    [XmlAttribute("bap_pet")] public int bap_pet_value_base;

    public int StatValue(byte i) => i switch {
        0 => str_value_base,
        1 => dex_value_base,
        2 => int_value_base,
        3 => luk_value_base,
        4 => hp_value_base,
        5 => hp_rgp_value_base,
        6 => hp_inv_value_base,
        7 => sp_value_base,
        8 => sp_rgp_value_base,
        9 => sp_inv_value_base,
        10 => ep_value_base,
        11 => ep_rgp_value_base,
        12 => ep_inv_value_base,
        13 => asp_value_base,
        14 => msp_value_base,
        15 => atp_value_base,
        16 => evp_value_base,
        17 => cap_value_base,
        18 => cad_value_base,
        19 => car_value_base,
        20 => ndd_value_base,
        23 => pap_value_base,
        24 => map_value_base,
        25 => par_value_base,
        26 => mar_value_base,
        27 => wapmin_value_base,
        28 => wapmax_value_base,
        29 => dmg_value_base,
        30 => dmg_value_base,
        32 => rmsp_value_base,
        33 => bap_value_base,
        34 => bap_pet_value_base,
        _ => throw new ArgumentOutOfRangeException(nameof(i), i, null),
    };
    #endregion

    #region StatRate

    [XmlAttribute("abp")] public float abp_rate_base;
    [XmlAttribute("jmp")] public float jmp_rate_base;
    [XmlAttribute("pen")] public float pen_rate_base;

    public float StatRate(byte i) => i switch {
        21 => abp_rate_base,
        22 => jmp_rate_base,
        31 => pen_rate_base,
        _ => throw new ArgumentOutOfRangeException(nameof(i), i, null),
    };
    #endregion

    #region SpecialValue
    [XmlAttribute("dashDistance")] public int dashDistance;
    [XmlAttribute("killHPRestore")] public int killHPRestore;
    [XmlAttribute("killSPRestore")] public int killSPRestore;
    [XmlAttribute("killEPRestore")] public int killEPRestore;
    [XmlAttribute("KnockBackReduce")] public int KnockBackReduce;
    [XmlAttribute("pvpdamageincrease")] public int pvpdamageincrease;
    [XmlAttribute("pvpdamagereduce")] public int pvpdamagereduce;
    [XmlAttribute("skill_levelup_tier_1")] public int skill_levelup_tier_1;
    [XmlAttribute("skill_levelup_tier_2")] public int skill_levelup_tier_2;
    [XmlAttribute("skill_levelup_tier_3")] public int skill_levelup_tier_3;
    [XmlAttribute("skill_levelup_tier_4")] public int skill_levelup_tier_4;
    [XmlAttribute("skill_levelup_tier_5")] public int skill_levelup_tier_5;
    [XmlAttribute("skill_levelup_tier_6")] public int skill_levelup_tier_6;
    [XmlAttribute("skill_levelup_tier_7")] public int skill_levelup_tier_7;
    [XmlAttribute("skill_levelup_tier_8")] public int skill_levelup_tier_8;
    [XmlAttribute("skill_levelup_tier_9")] public int skill_levelup_tier_9;
    [XmlAttribute("skill_levelup_tier_10")] public int skill_levelup_tier_10;
    [XmlAttribute("skill_levelup_tier_11")] public int skill_levelup_tier_11;
    [XmlAttribute("skill_levelup_tier_12")] public int skill_levelup_tier_12;
    [XmlAttribute("skill_levelup_tier_13")] public int skill_levelup_tier_13;
    [XmlAttribute("skill_levelup_tier_14")] public int skill_levelup_tier_14;
    [XmlAttribute("improve_massive_ox_msp")] public int improve_massive_ox_msp;
    [XmlAttribute("improve_massive_trapmaster_msp")] public int improve_massive_trapmaster_msp;
    [XmlAttribute("improve_massive_finalsurvival_msp")] public int improve_massive_finalsurvival_msp;
    [XmlAttribute("improve_massive_crazyrunner_msp")] public int improve_massive_crazyrunner_msp;
    [XmlAttribute("improve_massive_escape_msp")] public int improve_massive_escape_msp;
    [XmlAttribute("improve_massive_springbeach_msp")] public int improve_massive_springbeach_msp;
    [XmlAttribute("improve_massive_dancedance_msp")] public int improve_massive_dancedance_msp;
    [XmlAttribute("complete_fieldmission_msp")] public int complete_fieldmission_msp;
    [XmlAttribute("additionaleffect_95000012")] public int additionaleffect_95000012;
    [XmlAttribute("additionaleffect_95000014")] public int additionaleffect_95000014;
    [XmlAttribute("improve_chaosraid_asp")] public int improve_chaosraid_asp;
    [XmlAttribute("improve_chaosraid_atp")] public int improve_chaosraid_atp;
    [XmlAttribute("improve_chaosraid_hp")] public int improve_chaosraid_hp;
    [XmlAttribute("improve_pettrap_reward")] public int improve_pettrap_reward;
    [XmlAttribute("improve_massive_sh_crazyrunner_msp")] public int improve_massive_sh_crazyrunner_msp;
    [XmlAttribute("defensive_damageV")] public int defensive_damageV;
    [XmlAttribute("cap_ignore_limit")] public int cap_ignore_limit;
    [XmlAttribute("cad_ignore_limit")] public int cad_ignore_limit;
    [XmlAttribute("improve_stat_major")] public int improve_stat_major;


    public int SpecialValue(byte i) => i switch {
        4 => dashDistance,
        13 => killHPRestore,
        14 => killSPRestore,
        15 => killEPRestore,
        39 => KnockBackReduce,
        54 => pvpdamageincrease,
        55 => pvpdamagereduce,
        77 => skill_levelup_tier_1,
        78 => skill_levelup_tier_2,
        79 => skill_levelup_tier_3,
        80 => skill_levelup_tier_4,
        81 => skill_levelup_tier_5,
        82 => skill_levelup_tier_6,
        83 => skill_levelup_tier_7,
        84 => skill_levelup_tier_8,
        85 => skill_levelup_tier_9,
        86 => skill_levelup_tier_10,
        87 => skill_levelup_tier_11,
        88 => skill_levelup_tier_12,
        89 => skill_levelup_tier_13,
        90 => skill_levelup_tier_14,
        98 => improve_massive_ox_msp,
        99 => improve_massive_trapmaster_msp,
        100 => improve_massive_finalsurvival_msp,
        101 => improve_massive_crazyrunner_msp,
        102 => improve_massive_escape_msp,
        103 => improve_massive_springbeach_msp,
        104 => improve_massive_dancedance_msp,
        114 => complete_fieldmission_msp,
        117 => additionaleffect_95000012,
        118 => additionaleffect_95000014,
        148 => improve_chaosraid_asp,
        149 => improve_chaosraid_atp,
        150 => improve_chaosraid_hp,
        152 => str_value_base,
        153 => dex_value_base,
        154 => int_value_base,
        155 => luk_value_base,
        156 => improve_pettrap_reward,
        162 => improve_massive_sh_crazyrunner_msp,
        171 => defensive_damageV,
        180 => hp_value_base,
        181 => hp_rgp_value_base,
        182 => sp_value_base,
        183 => sp_rgp_value_base,
        184 => ep_value_base,
        185 => ep_inv_value_base,
        186 => asp_value_base,
        187 => msp_value_base,
        188 => atp_value_base,
        189 => evp_value_base,
        190 => cap_value_base,
        191 => cad_value_base,
        192 => car_value_base,
        193 => ndd_value_base,
        195 => pap_value_base,
        196 => map_value_base,
        197 => par_value_base,
        198 => mar_value_base,
        200 => rmsp_value_base,
        201 => bap_value_base,
        202 => cap_ignore_limit,
        203 => cad_ignore_limit,
        207 => improve_stat_major,
        _ => throw new ArgumentOutOfRangeException(nameof(i), i, null),
    };
    #endregion

    #region SpecialRate
    [XmlAttribute("seg")] public float seg;
    [XmlAttribute("smd")] public float smd;
    [XmlAttribute("sss")] public float sss;
    [XmlAttribute("finalAttackPower")] public float finalAttackPower;
    [XmlAttribute("wapRate")] public float wapRate;
    [XmlAttribute("finalAdditionalDamage")] public float finalAdditionalDamage;
    [XmlAttribute("cri")] public float cri;
    [XmlAttribute("sgi")] public float sgi;
    [XmlAttribute("atpToBap")] public float atpToBap;
    [XmlAttribute("sgi_elite")] public float sgi_elite;
    [XmlAttribute("sgi_boss")] public float sgi_boss;
    [XmlAttribute("heal")] public float heal;
    [XmlAttribute("receivedhealincrease")] public float receivedhealincrease;
    [XmlAttribute("iceDamage")] public float iceDamage;
    [XmlAttribute("fireDamage")] public float fireDamage;
    [XmlAttribute("darkDamage")] public float darkDamage;
    [XmlAttribute("lightDamage")] public float lightDamage;
    [XmlAttribute("poisonDamage")] public float poisonDamage;
    [XmlAttribute("thunderDamage")] public float thunderDamage;
    [XmlAttribute("nddincrease")] public float nddincrease;
    [XmlAttribute("lddincrease")] public float lddincrease;
    [XmlAttribute("parpen")] public float parpen;
    [XmlAttribute("marpen")] public float marpen;
    [XmlAttribute("icedamagereduce")] public float icedamagereduce;
    [XmlAttribute("firedamagereduce")] public float firedamagereduce;
    [XmlAttribute("darkdamagereduce")] public float darkdamagereduce;
    [XmlAttribute("lightdamagereduce")] public float lightdamagereduce;
    [XmlAttribute("poisondamagereduce")] public float poisondamagereduce;
    [XmlAttribute("thunderdamagereduce")] public float thunderdamagereduce;
    [XmlAttribute("stunReduce")] public float stunReduce;
    [XmlAttribute("skillCooldown")] public float skillCooldown;
    [XmlAttribute("conditionReduce")] public float conditionReduce;
    [XmlAttribute("nearDistanceDamageReduce")] public float nearDistanceDamageReduce;
    [XmlAttribute("longDistanceDamageReduce")] public float longDistanceDamageReduce;
    [XmlAttribute("strRate")] public float strRate;
    [XmlAttribute("dexRate")] public float dexRate;
    [XmlAttribute("intRate")] public float intRate;
    [XmlAttribute("lukRate")] public float lukRate;
    [XmlAttribute("hpRate")] public float hpRate;
    [XmlAttribute("hpInvRate")] public float hpInvRate;
    [XmlAttribute("spRate")] public float spRate;
    [XmlAttribute("spInvRate")] public float spInvRate;
    [XmlAttribute("npcKillDropItemIncRate")] public float npcKillDropItemIncRate;
    [XmlAttribute("seg_questReward")] public float seg_questReward;
    [XmlAttribute("epRate")] public float epRate;
    [XmlAttribute("epInvRate")] public float epInvRate;
    [XmlAttribute("aspRate")] public float aspRate;
    [XmlAttribute("mspRate")] public float mspRate;
    [XmlAttribute("improveguildexp")] public float improveguildexp;
    [XmlAttribute("improveguildcoin")] public float improveguildcoin;
    [XmlAttribute("improvemassiveeventbexpball")] public float improvemassiveeventbexpball;
    [XmlAttribute("seg_fishingReward")] public float seg_fishingReward;
    [XmlAttribute("seg_arcadeReward")] public float seg_arcadeReward;
    [XmlAttribute("seg_playinstrumentReward")] public float seg_playinstrumentReward;
    [XmlAttribute("improve_maid_mood")] public float improve_maid_mood;
    [XmlAttribute("reduce_maid_recipe")] public float reduce_maid_recipe;
    [XmlAttribute("reduce_meso_trade_fee")] public float reduce_meso_trade_fee;
    [XmlAttribute("reduce_enchant_matrial_fee")] public float reduce_enchant_matrial_fee;
    [XmlAttribute("reduce_merat_revival_fee")] public float reduce_merat_revival_fee;
    [XmlAttribute("improve_mining_reward_item")] public float improve_mining_reward_item;
    [XmlAttribute("improve_breeding_reward_item")] public float improve_breeding_reward_item;
    [XmlAttribute("improve_blacksmithing_reward_mastery")] public float improve_blacksmithing_reward_mastery;
    [XmlAttribute("improve_engraving_reward_mastery")] public float improve_engraving_reward_mastery;
    [XmlAttribute("improve_gathering_reward_item")] public float improve_gathering_reward_item;
    [XmlAttribute("improve_farming_reward_item")] public float improve_farming_reward_item;
    [XmlAttribute("improve_alchemist_reward_mastery")] public float improve_alchemist_reward_mastery;
    [XmlAttribute("improve_cooking_reward_mastery")] public float improve_cooking_reward_mastery;
    [XmlAttribute("improve_acquire_gathering_exp")] public float improve_acquire_gathering_exp;
    [XmlAttribute("improve_acquire_manufacturing_exp")] public float improve_acquire_manufacturing_exp;
    [XmlAttribute("improve_massive_ox_exp")] public float improve_massive_ox_exp;
    [XmlAttribute("improve_massive_trapmaster_exp")] public float improve_massive_trapmaster_exp;
    [XmlAttribute("improve_massive_finalsurvival_exp")] public float improve_massive_finalsurvival_exp;
    [XmlAttribute("improve_massive_crazyrunner_exp")] public float improve_massive_crazyrunner_exp;
    [XmlAttribute("improve_massive_escape_exp")] public float improve_massive_escape_exp;
    [XmlAttribute("improve_massive_springbeach_exp")] public float improve_massive_springbeach_exp;
    [XmlAttribute("improve_massive_dancedance_exp")] public float improve_massive_dancedance_exp;
    [XmlAttribute("npc_hit_reward_sp_ball")] public float npc_hit_reward_sp_ball;
    [XmlAttribute("npc_hit_reward_ep_ball")] public float npc_hit_reward_ep_ball;
    [XmlAttribute("improve_honor_token")] public float improve_honor_token;
    [XmlAttribute("improve_pvp_exp")] public float improve_pvp_exp;
    [XmlAttribute("improve_darkstream_damage")] public float improve_darkstream_damage;
    [XmlAttribute("reduce_darkstream_recive_damage")] public float reduce_darkstream_recive_damage;
    [XmlAttribute("strToInt")] public float strToInt;
    [XmlAttribute("fishing_double_mastery")] public float fishing_double_mastery;
    [XmlAttribute("playinstrument_double_mastery")] public float playinstrument_double_mastery;
    [XmlAttribute("improve_glide_vertical_velocity")] public float improve_glide_vertical_velocity;
    [XmlAttribute("rmspRate")] public float rmspRate;
    [XmlAttribute("atpRate")] public float atpRate;
    [XmlAttribute("evpRate")] public float evpRate;
    [XmlAttribute("capRate")] public float capRate;
    [XmlAttribute("carRate")] public float carRate;
    [XmlAttribute("nddRate")] public float nddRate;
    [XmlAttribute("jmpRate")] public float jmpRate;
    [XmlAttribute("papRate")] public float papRate;
    [XmlAttribute("mapRate")] public float mapRate;
    [XmlAttribute("parRate")] public float parRate;
    [XmlAttribute("marRate")] public float marRate;
    [XmlAttribute("reduce_recovery_ep_inv")] public float reduce_recovery_ep_inv;
    [XmlAttribute("improve_stat_wap_u")] public float improve_stat_wap_u;
    [XmlAttribute("mining_double_reward")] public float mining_double_reward;
    [XmlAttribute("breeding_double_reward")] public float breeding_double_reward;
    [XmlAttribute("gathering_double_reward")] public float gathering_double_reward;
    [XmlAttribute("farming_double_reward")] public float farming_double_reward;
    [XmlAttribute("blacksmithing_double_reward")] public float blacksmithing_double_reward;
    [XmlAttribute("engraving_double_reward")] public float engraving_double_reward;
    [XmlAttribute("alchemist_double_reward")] public float alchemist_double_reward;
    [XmlAttribute("cooking_double_reward")] public float cooking_double_reward;
    [XmlAttribute("mining_double_mastery")] public float mining_double_mastery;
    [XmlAttribute("breeding_double_mastery")] public float breeding_double_mastery;
    [XmlAttribute("gathering_double_mastery")] public float gathering_double_mastery;
    [XmlAttribute("farming_double_mastery")] public float farming_double_mastery;
    [XmlAttribute("blacksmithing_double_mastery")] public float blacksmithing_double_mastery;
    [XmlAttribute("engraving_double_mastery")] public float engraving_double_mastery;
    [XmlAttribute("alchemist_double_mastery")] public float alchemist_double_mastery;
    [XmlAttribute("cooking_double_mastery")] public float cooking_double_mastery;
    [XmlAttribute("improve_chaosraid_wap")] public float improve_chaosraid_wap;
    [XmlAttribute("improve_recovery_ball")] public float improve_recovery_ball;
    [XmlAttribute("mining_multiaction")] public float mining_multiaction;
    [XmlAttribute("breeding_multiaction")] public float breeding_multiaction;
    [XmlAttribute("gathering_multiaction")] public float gathering_multiaction;
    [XmlAttribute("farming_multiaction")] public float farming_multiaction;
    [XmlAttribute("improve_massive_sh_crazyrunner_exp")] public float improve_massive_sh_crazyrunner_exp;
    [XmlAttribute("reduce_damage_by_targetmaxhp")] public float reduce_damage_by_targetmaxhp;
    [XmlAttribute("reduce_meso_revival_fee")] public float reduce_meso_revival_fee;
    [XmlAttribute("improve_riding_run_speed")] public float improve_riding_run_speed;
    [XmlAttribute("improve_dungeon_reward_meso")] public float improve_dungeon_reward_meso;
    [XmlAttribute("improve_shop_buying_meso")] public float improve_shop_buying_meso;
    [XmlAttribute("improve_itembox_reward_meso")] public float improve_itembox_reward_meso;
    [XmlAttribute("reduce_remakeoption_fee")] public float reduce_remakeoption_fee;
    [XmlAttribute("reduce_airtaxi_fee")] public float reduce_airtaxi_fee;
    [XmlAttribute("reduce_gemstone_upgrade_fee")] public float reduce_gemstone_upgrade_fee;
    [XmlAttribute("reduce_pet_remakeoption_fee")] public float reduce_pet_remakeoption_fee;
    [XmlAttribute("improve_riding_speed")] public float improve_riding_speed;
    [XmlAttribute("defensive_physicaldamage")] public float defensive_physicaldamage;
    [XmlAttribute("defensive_magicaldamage")] public float defensive_magicaldamage;
    [XmlAttribute("offensive_physicaldamage")] public float offensive_physicaldamage;
    [XmlAttribute("offensive_magicaldamage")] public float offensive_magicaldamage;
    [XmlAttribute("reduce_gameitem_socket_unlock_fee")] public float reduce_gameitem_socket_unlock_fee;
    [XmlAttribute("aevp")] public float aevp;
    [XmlAttribute("cap_ignore_limit_extra")] public float cap_ignore_limit_extra;
    [XmlAttribute("reduce_do_heal_hp")] public float reduce_do_heal_hp;

    public float SpecialRate(byte i) => i switch {
        1 => seg,
        2 => smd,
        3 => sss,
        5 => finalAttackPower,
        6 => wapRate,
        7 => finalAdditionalDamage,
        8 => cri,
        9 => sgi,
        10 => atpToBap,
        11 => sgi_elite,
        12 => sgi_boss,
        16 => heal,
        17 => receivedhealincrease,
        18 => iceDamage,
        19 => fireDamage,
        20 => darkDamage,
        21 => lightDamage,
        22 => poisonDamage,
        23 => thunderDamage,
        24 => nddincrease,
        25 => lddincrease,
        26 => parpen,
        27 => marpen,
        28 => icedamagereduce,
        29 => firedamagereduce,
        30 => darkdamagereduce,
        31 => lightdamagereduce,
        32 => poisondamagereduce,
        33 => thunderdamagereduce,
        34 => stunReduce,
        35 => skillCooldown,
        36 => conditionReduce,
        37 => nearDistanceDamageReduce,
        38 => longDistanceDamageReduce,
        40 => strRate,
        41 => dexRate,
        42 => intRate,
        43 => lukRate,
        44 => hpRate,
        45 => hpInvRate,
        46 => spRate,
        47 => spInvRate,
        48 => npcKillDropItemIncRate,
        49 => seg_questReward,
        50 => epRate,
        51 => epInvRate,
        52 => aspRate,
        53 => mspRate,
        56 => improveguildexp,
        57 => improveguildcoin,
        58 => improvemassiveeventbexpball,
        59 => seg_fishingReward,
        60 => seg_arcadeReward,
        61 => seg_playinstrumentReward,
        62 => improve_maid_mood,
        63 => reduce_maid_recipe,
        64 => reduce_meso_trade_fee,
        65 => reduce_enchant_matrial_fee,
        66 => reduce_merat_revival_fee,
        67 => improve_mining_reward_item,
        68 => improve_breeding_reward_item,
        69 => improve_blacksmithing_reward_mastery,
        70 => improve_engraving_reward_mastery,
        71 => improve_gathering_reward_item,
        72 => improve_farming_reward_item,
        73 => improve_alchemist_reward_mastery,
        74 => improve_cooking_reward_mastery,
        75 => improve_acquire_gathering_exp,
        76 => improve_acquire_manufacturing_exp,
        91 => improve_massive_ox_exp,
        92 => improve_massive_trapmaster_exp,
        93 => improve_massive_finalsurvival_exp,
        94 => improve_massive_crazyrunner_exp,
        95 => improve_massive_escape_exp,
        96 => improve_massive_springbeach_exp,
        97 => improve_massive_dancedance_exp,
        105 => npc_hit_reward_sp_ball,
        106 => npc_hit_reward_ep_ball,
        107 => improve_honor_token,
        108 => improve_pvp_exp,
        109 => improve_darkstream_damage,
        110 => reduce_darkstream_recive_damage,
        111 => strToInt,
        112 => fishing_double_mastery,
        113 => playinstrument_double_mastery,
        115 => improve_glide_vertical_velocity,
        116 => rmspRate,
        119 => atpRate,
        120 => evpRate,
        121 => capRate,
        122 => carRate,
        123 => nddRate,
        124 => jmpRate,
        125 => papRate,
        126 => mapRate,
        127 => parRate,
        128 => marRate,
        129 => reduce_recovery_ep_inv,
        130 => improve_stat_wap_u,
        131 => mining_double_reward,
        132 => breeding_double_reward,
        133 => gathering_double_reward,
        134 => farming_double_reward,
        135 => blacksmithing_double_reward,
        136 => engraving_double_reward,
        137 => alchemist_double_reward,
        138 => cooking_double_reward,
        139 => mining_double_mastery,
        140 => breeding_double_mastery,
        141 => gathering_double_mastery,
        142 => farming_double_mastery,
        143 => blacksmithing_double_mastery,
        144 => engraving_double_mastery,
        145 => alchemist_double_mastery,
        146 => cooking_double_mastery,
        147 => improve_chaosraid_wap,
        151 => improve_recovery_ball,
        157 => mining_multiaction,
        158 => breeding_multiaction,
        159 => gathering_multiaction,
        160 => farming_multiaction,
        161 => improve_massive_sh_crazyrunner_exp,
        163 => reduce_damage_by_targetmaxhp,
        164 => reduce_meso_revival_fee,
        165 => improve_riding_run_speed,
        166 => improve_dungeon_reward_meso,
        167 => improve_shop_buying_meso,
        168 => improve_itembox_reward_meso,
        169 => reduce_remakeoption_fee,
        170 => reduce_airtaxi_fee,
        172 => reduce_gemstone_upgrade_fee,
        173 => reduce_pet_remakeoption_fee,
        174 => improve_riding_speed,
        175 => defensive_physicaldamage,
        176 => defensive_magicaldamage,
        177 => offensive_physicaldamage,
        178 => offensive_magicaldamage,
        179 => reduce_gameitem_socket_unlock_fee,
        194 => abp_rate_base,
        199 => pen_rate_base,
        204 => aevp,
        205 => cap_ignore_limit_extra,
        206 => reduce_do_heal_hp,
        _ => throw new ArgumentOutOfRangeException(nameof(i), i, null),
    };
    #endregion
}
