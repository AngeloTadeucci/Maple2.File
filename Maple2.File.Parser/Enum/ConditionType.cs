﻿namespace Maple2.File.Parser.Enum;

public enum ConditionType {
    unknown = 0,

    // group 0
    empty = 1,

    // group 1
    npc = 11,
    npc_no_damage = 12,
    npc_timeattack = 13,
    npc_race = 18,
    spawner = 17,
    npc_field_boss = 20,
    npc_field_elite = 21,
    npc_dungeon_boss = 22,
    npc_event_tag = 24,

    // group 2
    npc_lasthit = 14,
    npc_lasthit_buff = 15,
    npc_lasthit_time = 16,

    // group 3
    killcount = 19,

    // group 4
    npc_assist_bonus = 23,

    // group 7
    level = 40,
    level_up = 41,
    exp = 42,
    exp_rate = 43,
    adventure_level = 44,
    adventure_level_up = 45,
    level_max = 322,

    // group 8
    item_pickup = 2,
    item_exist = 3,
    item_inven = 4,
    item_break = 5,
    item_add = 6,
    item_destroy = 7,
    item_collect = 8,
    item_gear_score = 9,
    item_collect_revise = 10,

    // group 9
    map = 36,
    explore = 37,
    continent = 38,
    explore_continent = 39,

    // group 10
    meso_donation = 72,
    meso = 73,
    get_karma_token = 74,
    get_honor_token = 75,
    get_lu_token = 76,
    get_habi_token = 77,
    get_reverse_coin = 79,
    get_mentor_token = 80,
    get_mentee_token = 81,
    get_star_point = 82,
    use_merat = 83,

    // group 11
    quest_clear = 46,
    quest = 47,
    quest_revise_achieve = 48,
    quest_clear_by_chapter = 49,
    quest_daily = 50,
    quest_guide = 51,
    quest_accept = 52,
    field_mission = 53,
    mission_point = 54,
    fame_point = 55,
    fame_grade = 56,
    quest_field = 57,
    quest_field_first_clear = 58,
    quest_alliance = 59,
    quest_alliance_by_grade = 60,
    mission_attack_system = 61,
    skyfortress_system = 62,
    repeat_quest_clear = 63,

    // group 12
    job = 69,
    job_change = 70,
    subjob_change = 71,

    // group 13
    change_equip = 170,
    change_ugc_equip = 171,
    equip_exist = 172,

    // group 14
    holdtime = 146,
    ropetime = 147,
    laddertime = 148,
    emotiontime = 149,
    swimtime = 150,
    playinstrument_time = 151,
    play_ensenble_time = 152,

    // group 15
    run = 139,
    swim = 140,
    climb = 141,
    glide = 142,
    riding = 143,
    crawl = 144,
    fall = 145,

    // group 16
    jump = 203,

    // group 17
    playtime = 64,
    stay_map = 65,
    survive_map = 66,
    stay_cube = 67,
    survive_cube = 68,

    // group 18
    skill = 84,
    skill_die = 85,
    skill_damage_npc = 86,

    // group 19
    buff = 87,

    // group 21
    taxifind = 88,
    taxiuse = 89,
    taxifee = 90,
    best_taxi_use = 91,
    best_taxi_fee = 92,

    // group 22
    trophy_point = 94,
    hero_achieve_grade = 95,
    hero_achieve = 93,
    revise_achieve_single_grade = 96,
    revise_achieve_multi_grade = 97,

    // group 23
    shop_buy = 100,
    shop_buy_karma_token = 101,
    shop_buy_honor_token = 102,
    shop_sell = 103,
    shop_buy_lu_token = 104,
    shop_buy_habi_token = 105,
    shop_buy_reverse_coin = 106,
    shop_buy_mentro_token = 107,
    shop_buy_mentee_token = 108,
    shop_buy_star_point = 109,
    limited_bundle_buy = 110,

    // group 24
    revival = 98,
    hit_tombstone = 99,

    // group 25
    pvp_win = 111,
    pvp_kill = 112,
    pvp_die = 113,
    guildpvp_win = 114,
    guildpvp_kill = 115,
    guildpvp_die = 116,
    pvp_win_score = 117,
    pvp_win_time = 118,
    pvp_participation = 119,
    pvp_win_with_buff = 228,
    pvp_win_with_grade = 229,
    pvp_win_perfect = 230,

    // group 26
    shadow_world_kill = 120,
    shadow_world_die = 121,

    // group 27
    enchant_result = 122,
    unlimited_enchant = 321,

    // group 28
    beauty_add = 123,
    beauty_change = 124,
    beauty_change_color = 125,
    beauty_random = 126,
    beauty_style_add = 127,
    beauty_style_apply = 128,

    // group 29
    trigger = 129,
    minigame_clear = 130,
    useropen_minigame_clear = 131,
    guild_trigger = 263,

    // group 30
    guild_join = 132,
    guild_join_req = 133,
    guild_championship = 134,
    guild_exp = 135,
    guild_trophy = 136,
    guild_attendance = 137,
    guild_donate = 138,

    // group 31
    emotion = 153,
    couple_dance_event = 154,

    // group 32
    send_mail = 168,

    // group 33
    resolve_panelty = 169,

    // group 34
    interior_exp = 161,
    interior_level = 163,
    interior_exp_offset = 162,
    interior_point = 164,
    enter_otherhouse = 165,
    change_profile = 173,
    banner = 174,
    commend_home = 175,
    home_doctor = 176,
    home_bank = 177,
    home_goto = 178,
    item_design = 179,

    // group 35
    fall_survive = 180,
    fall_die = 181,
    fall_damage = 182,

    // group 38
    interact_object = 28,
    interact_object_rep = 29,
    breakable_object = 30,
    vibrate_object = 31,
    controller = 32,
    controller_mine = 33,
    controller_other = 34,
    splash_plant = 35,
    nurturing_play = 305,
    nurturing_eat = 306,
    nurturing_growth = 307,

    // group 39
    dialogue = 25,
    talk_in = 26,
    interact_npc = 27,

    // group 40
    item_move = 155,
    buy_house = 156,
    extend_house = 157,
    install_item = 158,
    uninstall_item = 159,
    rotate_cube = 160,
    buy_cube = 166,
    create_blueprint = 167,

    // group 41
    attendance = 183,

    // group 42
    dungeon_key_use = 184,
    dungeon_reward = 185,
    dungeon_reward_group = 186,
    dungeon_random_bonus = 187,
    dungeon_help_beginner = 188,
    dungeon_help_beginner_helper = 189,
    dungeon_help_beginner_helpee = 190,
    dungeon_rank = 193,
    dungeon_rank_clear = 192,
    dungeon_rank_clear_group = 191,
    dungeon_clear = 194,
    dungeon_clear_group = 195,
    dungeon_first_clear = 196,
    dungeon_round_clear = 197,

    // group 43
    maid_get_item = 198,
    maid_salary = 199,
    maid_jackpot = 200,
    maid_affinity = 201,
    maid_profile = 202,

    // group 45
    fish = 204,
    fish_success_bait = 205,
    fish_fail = 206,
    fish_big = 207,
    fish_collect = 208,
    fish_goldmedal = 209,
    auto_fishing = 210,

    // group 46
    music_play_score = 211,
    music_play_score_by_name = 212,
    music_play_score_time = 213,
    music_play_instrument_time = 214,
    music_play_instrument_mastery = 215,
    music_play_ensemble = 216,
    music_play_ensemble_in = 217,
    music_concert_cheer_up = 218,

    // group 47
    openItemBox = 219,
    openStoryBook = 220,
    festival_event = 221,
    install_billboard = 222,

    // group 52
    game_helper_service = 274,

    // group 53
    smart_push = 223,

    // group 55
    item_remake_option = 224,
    item_remake_option_record = 225,
    pet_remake_option = 226,
    pet_remake_option_record = 227,

    // group 56
    gemstone_upgrade = 231,
    gemstone_upgrade_success = 232,
    gemstone_upgrade_fail = 233,
    gemstone_upgrade_try = 234,
    gemstone_puton = 235,
    gemstone_putoff = 236,
    skin_gemstone_puton = 237,
    skin_gemstone_putoff = 238,
    equip_gemstone_puton = 239,
    equip_gemstone_putoff = 240,
    socket_unlock = 241,
    socket_unlock_success = 242,
    socket_unlock_fail = 243,
    socket_unlock_try = 244,

    // group 57
    character_ability_learn = 245,
    character_ability_reset = 246,

    // group 59
    mastery_grade = 247,
    set_mastery_grade = 248,
    music_play_grade = 249,
    fisher_grade = 250,
    mastery_harvest = 251,
    mastery_harvest_try = 252,
    mastery_harvest_otherhouse = 253,
    mastery_harvest_guildhouse = 254,
    mastery_manufacturing = 255,
    mastery_farming = 256,
    mastery_farming_try = 257,
    mastery_gathering = 258,
    mastery_gathering_try = 259,

    // group 60
    club_join = 260,
    buddy_request = 261,
    chat = 262,

    // group 62
    pet_collect = 264,
    pet_first_collect = 265,
    pet_enchant = 266,
    pet_enchant_exp = 267,
    pet_taming = 268,
    pet_catch_id = 271,
    pet_catch_grade = 270,
    pet_catch_category = 269,
    pet_evolution_point_by_rank = 272,
    pet_evolution_by_rank = 273,

    // group 63
    item_merge_success = 279,

    // group 64
    idip_app_attendance = 275,
    idip_live_broadcast = 276,
    idip_adventure_bar = 277,

    // group 65
    vipgm = 278,

    // group 66
    donation_item = 280,
    donation_type = 281,

    // group 67
    play_rps = 282,
    play_rps_win = 283,
    play_rps_lose = 284,
    play_rps_draw = 285,

    // group 68
    user_find = 286,

    // group 69
    survival_enter = 287,
    survival_kill = 288,
    survival_kill_outside = 289,
    survival_kill_use_skill = 290,
    survival_double_kill = 293,
    survival_win_without_interact = 294,
    survival_win_without_npckill = 295,
    survival_win_use_one_skill = 296,
    survival_total_kill_use_skill = 291,
    survival_total_kill_use_single_skill = 292,
    survival_rank_with_kill = 297,
    survival_breakable_object = 298,
    survival_npc_kill = 299,
    survival_item_get = 300,
    survival_buy_gold_pass = 301,

    // group 70
    worldchampion_hit = 302,
    worldchampion_damage = 303,
    worldchampion_reward = 304,

    // group 71
    lapenshard_upgrade_try = 308,
    lapenshard_upgrade_fail = 309,
    lapenshard_upgrade_success = 310,
    lapenshard_upgrade_result = 311,

    // group 72
    wedding_propose = 312,
    wedding_propose_decline = 313,
    wedding_propose_declined = 314,
    wedding_hall_reserve = 315,
    wedding_hall_change = 316,
    wedding_hall_cancel = 317,
    wedding_guest = 318,
    wedding_divorce = 319,
    wedding_complete = 320,
}
