using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.String;
using Maple2.File.Parser.Xml.Table;

namespace Maple2.File.Parser;

public class TableParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer nameSerializer;
    private readonly XmlSerializer bankTypeSerializer;
    private readonly XmlSerializer chatStickerSerializer;
    private readonly XmlSerializer defaultItemsSerializer;
    private readonly XmlSerializer dungeonRoomSerializer;
    private readonly XmlSerializer enchantScrollSerializer;
    private readonly XmlSerializer fishSerializer;
    private readonly XmlSerializer fishHabitatSerializer;
    private readonly XmlSerializer fishingRodSerializer;
    private readonly XmlSerializer fishingSpotSerializer;
    private readonly XmlSerializer guildBuffSerializer;
    private readonly XmlSerializer guildContributionSerializer;
    private readonly XmlSerializer guildEventSerializer;
    private readonly XmlSerializer guildExpSerializer;
    private readonly XmlSerializer guildHouseSerializer;
    private readonly XmlSerializer guildNpcSerializer;
    private readonly XmlSerializer guildPropertySerializer;
    private readonly XmlSerializer instrumentCategoryInfoSerializer;
    private readonly XmlSerializer instrumentInfoSerializer;
    private readonly XmlSerializer interactObjectSerializer;
    private readonly XmlSerializer itemBreakIngredientSerializer;
    private readonly XmlSerializer itemExchangeScrollSerializer;
    private readonly XmlSerializer itemExtractionSerializer;
    private readonly XmlSerializer itemGemstoneUpgradeSerializer;
    private readonly XmlSerializer itemLapenshardUpgradeSerializer;
    private readonly XmlSerializer itemRemakeScrollSerializer;
    private readonly XmlSerializer itemRepackingScrollSerializer;
    private readonly XmlSerializer itemSocketSerializer;
    private readonly XmlSerializer itemSocketScrollSerializer;
    private readonly XmlSerializer jobSerializer;
    private readonly XmlSerializer magicPathSerializer;
    private readonly XmlSerializer mapSpawnTagSerializer;
    private readonly XmlSerializer masteryRecipeSerializer;
    private readonly XmlSerializer masteryRewardSerializer;
    private readonly XmlSerializer paletteSerializer;
    private readonly XmlSerializer petExpSerializer;
    private readonly XmlSerializer petPropertySerializer;
    private readonly XmlSerializer petSpawnInfoSerializer;
    private readonly XmlSerializer premiumClubEffectSerializer;
    private readonly XmlSerializer premiumClubItemSerializer;
    private readonly XmlSerializer premiumClubPackageSerializer;
    private readonly XmlSerializer setItemInfoSerializer;
    private readonly XmlSerializer setItemOptionSerializer;
    private readonly XmlSerializer titleTagSerializer;
    private readonly XmlSerializer individualItemDropSerializer;
    private readonly XmlSerializer gachaInfoSerializer;
    private readonly XmlSerializer shopBeautyCouponSerializer;
    private readonly XmlSerializer meretmarketCategorySerializer;
    private readonly XmlSerializer expBaseSerializer;
    private readonly XmlSerializer nextExpSerializer;
    private readonly XmlSerializer adventureLevelAbilitySerializer;
    private readonly XmlSerializer adventureLevelMissionSerializer;
    private readonly XmlSerializer adventureLevelRewardSerializer;
    private readonly XmlSerializer ugcDesignSerializer;
    private readonly XmlSerializer bannerSerializer;
    private readonly XmlSerializer nameTagSymbolSerializer;
    private readonly XmlSerializer commonExpSerializer;
    private readonly XmlSerializer chapterBookSerializer;
    private readonly XmlSerializer learningQuestSerializer;
    private readonly XmlSerializer masteryDifferentialFactorSerializer;
    private readonly XmlSerializer rewardContentSerializer;
    private readonly XmlSerializer rewardContentItemSerializer;
    private readonly XmlSerializer rewardContentExpStaticSerializer;
    private readonly XmlSerializer rewardContentMesoSerializer;
    private readonly XmlSerializer rewardContentMesoStaticSerializer;
    private readonly XmlSerializer survivalLevelSerializer;
    private readonly XmlSerializer survivalLevelRewardSerializer;

    public TableParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.nameSerializer = new XmlSerializer(typeof(StringMapping));
        this.bankTypeSerializer = new XmlSerializer(typeof(BankTypeRoot));
        this.chatStickerSerializer = new XmlSerializer(typeof(ChatStickerRoot));
        this.defaultItemsSerializer = new XmlSerializer(typeof(DefaultItems));
        this.dungeonRoomSerializer = new XmlSerializer(typeof(DungeonRoomRoot));
        this.enchantScrollSerializer = new XmlSerializer(typeof(EnchantScrollRoot));
        this.fishSerializer = new XmlSerializer(typeof(FishRoot));
        this.fishHabitatSerializer = new XmlSerializer(typeof(FishHabitatRoot));
        this.fishingRodSerializer = new XmlSerializer(typeof(FishingRodRoot));
        this.fishingSpotSerializer = new XmlSerializer(typeof(FishingSpotRoot));
        this.guildBuffSerializer = new XmlSerializer(typeof(GuildBuffRoot));
        this.guildContributionSerializer = new XmlSerializer(typeof(GuildContributionRoot));
        this.guildEventSerializer = new XmlSerializer(typeof(GuildEventRoot));
        this.guildExpSerializer = new XmlSerializer(typeof(GuildExpRoot));
        this.guildHouseSerializer = new XmlSerializer(typeof(GuildHouseRoot));
        this.guildNpcSerializer = new XmlSerializer(typeof(GuildNpcRoot));
        this.guildPropertySerializer = new XmlSerializer(typeof(GuildPropertyRoot));
        this.instrumentCategoryInfoSerializer = new XmlSerializer(typeof(InstrumentCategoryInfoRoot));
        this.instrumentInfoSerializer = new XmlSerializer(typeof(InstrumentInfoRoot));
        this.interactObjectSerializer = new XmlSerializer(typeof(InteractObjectRoot));
        this.itemBreakIngredientSerializer = new XmlSerializer(typeof(ItemBreakIngredientRoot));
        this.itemExchangeScrollSerializer = new XmlSerializer(typeof(ItemExchangeScrollRoot));
        this.itemExtractionSerializer = new XmlSerializer(typeof(ItemExtractionRoot));
        this.itemGemstoneUpgradeSerializer = new XmlSerializer(typeof(ItemGemstoneUpgradeRoot));
        this.itemLapenshardUpgradeSerializer = new XmlSerializer(typeof(ItemLapenshardUpgradeRoot));
        this.itemRemakeScrollSerializer = new XmlSerializer(typeof(ItemRemakeScrollRoot));
        this.itemRepackingScrollSerializer = new XmlSerializer(typeof(ItemRepackingScrollRoot));
        this.itemSocketSerializer = new XmlSerializer(typeof(ItemSocketRoot));
        this.itemSocketScrollSerializer = new XmlSerializer(typeof(ItemSocketScrollRoot));
        this.jobSerializer = new XmlSerializer(typeof(JobRoot));
        this.magicPathSerializer = new XmlSerializer(typeof(MagicPath));
        this.mapSpawnTagSerializer = new XmlSerializer(typeof(MapSpawnTag));
        this.masteryRecipeSerializer = new XmlSerializer(typeof(MasteryRecipeRoot));
        this.masteryRewardSerializer = new XmlSerializer(typeof(MasteryRewardRoot));
        this.paletteSerializer = new XmlSerializer(typeof(ColorPaletteRoot));
        this.petExpSerializer = new XmlSerializer(typeof(PetExpRoot));
        this.petPropertySerializer = new XmlSerializer(typeof(PetPropertyRoot));
        this.petSpawnInfoSerializer = new XmlSerializer(typeof(PetSpawnInfoRoot));
        this.premiumClubEffectSerializer = new XmlSerializer(typeof(PremiumClubEffectRoot));
        this.premiumClubItemSerializer = new XmlSerializer(typeof(PremiumClubItemRoot));
        this.premiumClubPackageSerializer = new XmlSerializer(typeof(PremiumClubPackageRoot));
        this.setItemInfoSerializer = new XmlSerializer(typeof(SetItemInfoRoot));
        this.setItemOptionSerializer = new XmlSerializer(typeof(SetItemOptionRoot));
        this.titleTagSerializer = new XmlSerializer(typeof(TitleTagRoot));
        this.individualItemDropSerializer = new XmlSerializer(typeof(IndividualItemDropRoot));
        this.gachaInfoSerializer = new XmlSerializer(typeof(GachaInfoRoot));
        this.shopBeautyCouponSerializer = new XmlSerializer(typeof(ShopBeautyCouponRoot));
        this.meretmarketCategorySerializer = new XmlSerializer(typeof(MeretMarketCategoryRoot));
        this.expBaseSerializer = new XmlSerializer(typeof(ExpBaseRoot));
        this.nextExpSerializer = new XmlSerializer(typeof(NextExpRoot));
        this.adventureLevelAbilitySerializer = new XmlSerializer(typeof(AdventureLevelAbilityRoot));
        this.adventureLevelMissionSerializer = new XmlSerializer(typeof(AdventureLevelMissionRoot));
        this.adventureLevelRewardSerializer = new XmlSerializer(typeof(AdventureLevelRewardRoot));
        this.ugcDesignSerializer = new XmlSerializer(typeof(UgcDesignRoot));
        this.bannerSerializer = new XmlSerializer(typeof(BannerRoot));
        this.nameTagSymbolSerializer = new XmlSerializer(typeof(NameTagSymbolRoot));
        this.commonExpSerializer = new XmlSerializer(typeof(CommonExpRoot));
        this.chapterBookSerializer = new XmlSerializer(typeof(ChapterBookRoot));
        this.learningQuestSerializer = new XmlSerializer(typeof(LearningQuestRoot));
        this.masteryDifferentialFactorSerializer = new XmlSerializer(typeof(MasteryDifferentialFactorRoot));
        this.rewardContentSerializer = new XmlSerializer(typeof(RewardContentRoot));
        this.rewardContentItemSerializer = new XmlSerializer(typeof(RewardContentItemRoot));
        this.rewardContentExpStaticSerializer = new XmlSerializer(typeof(RewardContentExpStaticRoot));
        this.rewardContentMesoSerializer = new XmlSerializer(typeof(RewardContentMesoRoot));
        this.rewardContentMesoStaticSerializer = new XmlSerializer(typeof(RewardContentMesoStaticRoot));
        this.survivalLevelSerializer = new XmlSerializer(typeof(SurvivalLevelRoot));
        this.survivalLevelRewardSerializer = new XmlSerializer(typeof(SurvivalLevelRewardRoot));

        // var seen = new HashSet<string>();
        // this.bankTypeSerializer.UnknownAttribute += (sender, args) => {
        //     if (!seen.Contains(args.Attr.Name)) {
        //         Console.WriteLine($"Missing {args.Attr.Name}={args.Attr.Value}");
        //         seen.Add(args.Attr.Name);
        //     }
        // };
    }

    public IEnumerable<(int Id, BankType BankType)> ParseBankType() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/banktype.xml"));
        var data = bankTypeSerializer.Deserialize(reader) as BankTypeRoot;
        Debug.Assert(data != null);

        foreach (BankType type in data.bankType) {
            yield return (type.id, type);
        }
    }

    public IEnumerable<(int Id, ChatSticker ChatSticker)> ParseChatSticker() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/chatemoticon.xml"));
        var data = chatStickerSerializer.Deserialize(reader) as ChatStickerRoot;
        Debug.Assert(data != null);

        foreach (ChatSticker sticker in data.chatEmoticon) {
            yield return (sticker.id, sticker);
        }
    }

    public IEnumerable<(int Id, ColorPalette Palette)> ParseColorPalette() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/colorpalette.xml"));
        var data = paletteSerializer.Deserialize(reader) as ColorPaletteRoot;
        Debug.Assert(data != null);

        foreach (ColorPalette palette in data.colorPalette) {
            yield return (palette.id, palette);
        }
    }

    public IEnumerable<(int Id, ColorPalette Palette)> ParseColorPaletteAchieve() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/na/colorpalette_achieve.xml"));
        var data = paletteSerializer.Deserialize(reader) as ColorPaletteRoot;
        Debug.Assert(data != null);

        foreach (ColorPalette palette in data.colorPalette) {
            yield return (palette.id, palette);
        }
    }

    public IEnumerable<(int JobCode, string Slot, IList<DefaultItems.Item> Items)> ParseDefaultItems() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/defaultitems.xml"));
        var data = defaultItemsSerializer.Deserialize(reader) as DefaultItems;
        Debug.Assert(data != null);

        foreach (DefaultItems.Key key in data.key) {
            foreach (DefaultItems.Slot slot in key.slot) {
                yield return (key.jobCode, slot.name, slot.item);
            }
        }
    }

    public IEnumerable<(int Id, DungeonRoom Dungeon)> ParseDungeonRoom() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/na/dungeonroom.xml"));
        var data = dungeonRoomSerializer.Deserialize(reader) as DungeonRoomRoot;
        Debug.Assert(data != null);

        foreach (DungeonRoom dungeon in data.dungeonRoom) {
            yield return (dungeon.dungeonRoomID, dungeon);
        }
    }

    public IEnumerable<(int Id, EnchantScroll Scroll)> ParseEnchantScroll() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/enchantscroll.xml"));
        var data = enchantScrollSerializer.Deserialize(reader) as EnchantScrollRoot;
        Debug.Assert(data != null);

        foreach (EnchantScroll scroll in data.scroll) {
            yield return (scroll.id, scroll);
        }
    }

    public IEnumerable<(int Id, string Name, Fish Fish)> ParseFish() {
        XmlReader nameReader = xmlReader.GetXmlReader(xmlReader.GetEntry("en/stringfishname.xml"));
        var mapping = nameSerializer.Deserialize(nameReader) as StringMapping;
        Debug.Assert(mapping != null);

        Dictionary<int, string> fishNames = mapping.key.ToDictionary(key => int.Parse(key.id), key => key.name);

        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/fish.xml"));
        var data = fishSerializer.Deserialize(reader) as FishRoot;
        Debug.Assert(data != null);

        foreach (Fish fish in data.fish) {
            yield return (fish.id, fishNames.GetValueOrDefault(fish.id), fish);
        }
    }

    public IEnumerable<(int Id, FishHabitat Habitat)> ParseFishHabitat() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/fishhabitat.xml"));
        var data = fishHabitatSerializer.Deserialize(reader) as FishHabitatRoot;
        Debug.Assert(data != null);

        foreach (FishHabitat habitat in data.fish) {
            yield return (habitat.id, habitat);
        }
    }

    public IEnumerable<(int Id, FishingRod Rod)> ParseFishingRod() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/fishingrod.xml"));
        var data = fishingRodSerializer.Deserialize(reader) as FishingRodRoot;
        Debug.Assert(data != null);

        foreach (FishingRod rod in data.rod) {
            yield return (rod.rodCode, rod);
        }
    }

    public IEnumerable<(int Id, FishingSpot Spot)> ParseFishingSpot() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/fishingspot.xml"));
        var data = fishingSpotSerializer.Deserialize(reader) as FishingSpotRoot;
        Debug.Assert(data != null);

        foreach (FishingSpot spot in data.spot) {
            yield return (spot.id, spot);
        }
    }

    public IEnumerable<(int Id, IEnumerable<GuildBuff> Buffs)> ParseGuildBuff() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/guildbuff.xml"));
        var data = guildBuffSerializer.Deserialize(reader) as GuildBuffRoot;
        Debug.Assert(data != null);

        foreach (IGrouping<int, GuildBuff> group in data.guildBuff.GroupBy(guildBuff => guildBuff.id)) {
            yield return (group.Key, group);
        }
    }

    public IEnumerable<(GuildContributionType Type, GuildContribution Contribution)> ParseGuildContribution() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/guildcontribution.xml"));
        var data = guildContributionSerializer.Deserialize(reader) as GuildContributionRoot;
        Debug.Assert(data != null);

        foreach (GuildContribution contribution in data.contribution) {
            yield return (contribution.type, contribution);
        }
    }

    public IEnumerable<(int Id, GuildEvent Event)> ParseGuildEvent() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/guildcontribution.xml"));
        var data = guildEventSerializer.Deserialize(reader) as GuildEventRoot;
        Debug.Assert(data != null);

        foreach (GuildEvent @event in data.guildEvent) {
            yield return (@event.id, @event);
        }
    }

    public IEnumerable<(int Id, GuildExp Exp)> ParseGuildExp() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/guildexp.xml"));
        var data = guildExpSerializer.Deserialize(reader) as GuildExpRoot;
        Debug.Assert(data != null);

        foreach (GuildExp exp in data.guildExp) {
            yield return (exp.level, exp);
        }
    }

    public IEnumerable<(int Id, IEnumerable<GuildHouse> Houses)> ParseGuildHouse() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/guildhouse.xml"));
        var data = guildHouseSerializer.Deserialize(reader) as GuildHouseRoot;
        Debug.Assert(data != null);

        foreach (IGrouping<int, GuildHouse> group in data.guildHouse.GroupBy(guildHouse => guildHouse.level)) {
            yield return (group.Key, group);
        }
    }

    public IEnumerable<(GuildNpcType Type, IEnumerable<GuildNpc> Npcs)> ParseGuildNpc() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/guildnpc.xml"));
        var data = guildNpcSerializer.Deserialize(reader) as GuildNpcRoot;
        Debug.Assert(data != null);

        foreach (IGrouping<GuildNpcType, GuildNpc> group in data.npc.GroupBy(guildNpc => guildNpc.type)) {
            yield return (group.Key, group);
        }
    }

    public IEnumerable<(int Id, GuildProperty Property)> ParseGuildProperty() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/guildproperty.xml"));
        var data = guildPropertySerializer.Deserialize(reader) as GuildPropertyRoot;
        Debug.Assert(data != null);

        foreach (GuildProperty property in data.property) {
            yield return (property.level, property);
        }
    }

    public IEnumerable<(int Id, InstrumentCategoryInfo Info)> ParseInstrumentCategoryInfo() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/instrumentcategoryinfo.xml"));
        var data = instrumentCategoryInfoSerializer.Deserialize(reader) as InstrumentCategoryInfoRoot;
        Debug.Assert(data != null);

        foreach (InstrumentCategoryInfo instrument in data.category) {
            yield return (instrument.id, instrument);
        }
    }

    public IEnumerable<(int Id, InstrumentInfo Info)> ParseInstrumentInfo() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/instrumentinfo.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = instrumentInfoSerializer.Deserialize(reader) as InstrumentInfoRoot;
        Debug.Assert(data != null);

        foreach (InstrumentInfo instrument in data.instrument) {
            yield return (instrument.id, instrument);
        }
    }

    public IEnumerable<(int Id, string Name, InteractObject Info)> ParseInteractObject() {
        XmlReader nameReader = xmlReader.GetXmlReader(xmlReader.GetEntry("en/setitemname.xml"));
        var mapping = nameSerializer.Deserialize(nameReader) as StringMapping;
        Debug.Assert(mapping != null);

        Dictionary<int, string> interactNames = mapping.key.ToDictionary(key => int.Parse(key.id), key => key.name);

        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/interactobject.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = interactObjectSerializer.Deserialize(reader) as InteractObjectRoot;
        Debug.Assert(data != null);

        foreach (InteractObject interact in data.interact) {
            yield return (interact.id, interactNames.GetValueOrDefault(interact.id), interact);
        }
    }

    public IEnumerable<(int Id, InteractObject Info)> ParseInteractObjectMastery() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/interactobject_mastery.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = interactObjectSerializer.Deserialize(reader) as InteractObjectRoot;
        Debug.Assert(data != null);

        foreach (InteractObject interact in data.interact) {
            yield return (interact.id, interact);
        }
    }

    public IEnumerable<(int ItemId, ItemBreakIngredient Item)> ParseItemBreakIngredient() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/itembreakingredient.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = itemBreakIngredientSerializer.Deserialize(reader) as ItemBreakIngredientRoot;
        Debug.Assert(data != null);

        foreach (ItemBreakIngredient item in data.item) {
            yield return (item.ItemID, item);
        }
    }

    public IEnumerable<(int ExchangeId, ItemExchangeScroll ScrollExchange)> ParseItemExchangeScroll() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/itemexchangescrolltable.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = itemExchangeScrollSerializer.Deserialize(reader) as ItemExchangeScrollRoot;
        Debug.Assert(data != null);

        foreach (ItemExchangeScroll item in data.exchange) {
            yield return (item.id, item);
        }
    }

    public IEnumerable<(int Id, ItemExtraction Extraction)> ParseItemExtraction() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/na/itemextraction.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = itemExtractionSerializer.Deserialize(reader) as ItemExtractionRoot;
        Debug.Assert(data != null);

        foreach (ItemExtraction item in data.key) {
            yield return (item.TargetItemID, item);
        }
    }

    public IEnumerable<(int ItemId, ItemGemstoneUpgrade Item)> ParseItemGemstoneUpgrade() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/na/itemgemstoneupgrade.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = itemGemstoneUpgradeSerializer.Deserialize(reader) as ItemGemstoneUpgradeRoot;
        Debug.Assert(data != null);

        foreach (ItemGemstoneUpgrade key in data.key) {
            yield return (key.ItemId, key);
        }
    }

    public IEnumerable<(int ItemId, ItemLapenshardUpgrade Item)> ParseItemLapenshardUpgrade() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/na/itemlapenshardupgrade.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = itemLapenshardUpgradeSerializer.Deserialize(reader) as ItemLapenshardUpgradeRoot;
        Debug.Assert(data != null);

        foreach (ItemLapenshardUpgrade key in data.key) {
            yield return (key.ItemId, key);
        }
    }

    public IEnumerable<(int Id, ItemRemakeScroll Scroll)> ParseItemRemakeScroll() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/itemremakescroll.xml"));
        var data = itemRemakeScrollSerializer.Deserialize(reader) as ItemRemakeScrollRoot;
        Debug.Assert(data != null);

        foreach (ItemRemakeScroll scroll in data.remakeScroll) {
            yield return (scroll.id, scroll);
        }
    }

    public IEnumerable<(int Id, ItemRepackingScroll Scroll)> ParseItemRepackingScroll() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/itemrepackingscroll.xml"));
        var data = itemRepackingScrollSerializer.Deserialize(reader) as ItemRepackingScrollRoot;
        Debug.Assert(data != null);

        foreach (ItemRepackingScroll scroll in data.rePackingScroll) {
            yield return (scroll.id, scroll);
        }
    }

    public IEnumerable<(int Id, ItemSocket Socket)> ParseItemSocket() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/itemsocket.xml"));
        var data = itemSocketSerializer.Deserialize(reader) as ItemSocketRoot;
        Debug.Assert(data != null);

        foreach (ItemSocket socket in data.itemSocket) {
            yield return (socket.id, socket);
        }
    }

    public IEnumerable<(int Id, ItemSocketScroll Scroll)> ParseItemSocketScroll() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/itemsocketscroll.xml"));
        var data = itemSocketScrollSerializer.Deserialize(reader) as ItemSocketScrollRoot;
        Debug.Assert(data != null);

        foreach (ItemSocketScroll scroll in data.scroll) {
            yield return (scroll.id, scroll);
        }
    }

    public IEnumerable<JobTable> ParseJobTable() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/job.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = jobSerializer.Deserialize(reader) as JobRoot;
        Debug.Assert(data != null);

        foreach (JobTable job in data.job) {
            yield return job;
        }
    }

    public IEnumerable<(long Id, MagicType Type)> ParseMagicPath() {
        string sanitized = Sanitizer.SanitizeMagicPath(xmlReader.GetString(xmlReader.GetEntry("table/magicpath.xml")));
        var data = magicPathSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as MagicPath;
        Debug.Assert(data != null);

        foreach (MagicType type in data.type) {
            yield return (type.id, type);
        }
    }

    public IEnumerable<(int MapId, IEnumerable<MapSpawnTag.Region> Region)> ParseMapSpawnTag() {
        string sanitized = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/mapspawntag.xml")));
        var data = mapSpawnTagSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as MapSpawnTag;
        Debug.Assert(data != null);

        foreach (IGrouping<int, MapSpawnTag.Region> group in data.region.GroupBy(region => region.mapCode)) {
            yield return (group.Key, group);
        }
    }

    public IEnumerable<(int Id, MasteryRecipe Recipe)> ParseMasteryRecipe() {
        string sanitized = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/masteryreceipe.xml")));
        var data = masteryRecipeSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as MasteryRecipeRoot;
        Debug.Assert(data != null);

        foreach (MasteryRecipe recipe in data.receipe) {
            yield return (recipe.id, recipe);
        }
    }

    public IEnumerable<(MasteryType Type, MasteryReward Reward)> ParseMasteryReward() {
        string sanitized = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/mastery.xml")));
        var data = masteryRewardSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as MasteryRewardRoot;
        Debug.Assert(data != null);

        foreach (MasteryReward reward in data.mastery) {
            yield return (reward.type, reward);
        }
    }

    public IEnumerable<(short Level, PetExp Exp)> ParsePetExp() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/petexp.xml"));
        var data = petExpSerializer.Deserialize(reader) as PetExpRoot;
        Debug.Assert(data != null);

        foreach (PetExp exp in data.exp) {
            yield return (exp.level, exp);
        }
    }

    public IEnumerable<(int Id, PetProperty Property)> ParsePetProperty() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/petproperty.xml"));
        var data = petPropertySerializer.Deserialize(reader) as PetPropertyRoot;
        Debug.Assert(data != null);

        foreach (PetProperty property in data.pets) {
            yield return (property.code, property);
        }
    }

    public IEnumerable<(int FieldId, IEnumerable<PetSpawnInfo> Info)> ParsePetSpawnInfo() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/petspawninfo.xml"));
        var data = petSpawnInfoSerializer.Deserialize(reader) as PetSpawnInfoRoot;
        Debug.Assert(data != null);

        foreach (IGrouping<int, PetSpawnInfo> group in data.SpawnInfo.GroupBy(spawnInfo => spawnInfo.fieldID)) {
            yield return (group.Key, group);
        }
    }

    public IEnumerable<(int Id, PremiumClubEffect Effect)> ParsePremiumClubEffect() {
        string sanitized = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/vipbenefiteffecttable.xml")));
        var data = premiumClubEffectSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as PremiumClubEffectRoot;
        Debug.Assert(data != null);

        foreach (PremiumClubEffect effect in data.benefit) {
            yield return (effect.effectID, effect);
        }
    }

    public IEnumerable<(int Id, PremiumClubItem Item)> ParsePremiumClubItem() {
        string sanitized = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/vipbenefititemtable.xml")));
        var data = premiumClubItemSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as PremiumClubItemRoot;
        Debug.Assert(data != null);

        foreach (PremiumClubItem item in data.benefit) {
            yield return (item.id, item);
        }
    }

    public IEnumerable<(int Id, PremiumClubPackage Package)> ParsePremiumClubPackage() {
        string sanitized = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/vipgoodstable.xml")));
        var data = premiumClubPackageSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as PremiumClubPackageRoot;
        Debug.Assert(data != null);

        foreach (PremiumClubPackage package in data.goods) {
            yield return (package.id, package);
        }
    }

    public IEnumerable<(int Id, string Name, SetItemInfo Info)> ParseSetItemInfo() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("en/setitemname.xml"));
        var mapping = nameSerializer.Deserialize(reader) as StringMapping;
        Debug.Assert(mapping != null);

        Dictionary<int, string> setNames = mapping.key.ToDictionary(key => int.Parse(key.id), key => key.name);

        string sanitized = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/setiteminfo.xml")));
        var data = setItemInfoSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as SetItemInfoRoot;
        Debug.Assert(data != null);

        foreach (SetItemInfo info in data.set) {
            yield return (info.id, setNames.GetValueOrDefault(info.id), info);
        }
    }

    public IEnumerable<(int Id, SetItemOption Option)> ParseSetItemOption() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/setitemoption.xml"));
        var data = setItemOptionSerializer.Deserialize(reader) as SetItemOptionRoot;
        Debug.Assert(data != null);

        foreach (SetItemOption option in data.option) {
            yield return (option.id, option);
        }
    }

    public IEnumerable<(int Id, string Name, TitleTag TitleTag)> ParseTitleTag() {
        XmlReader nameReader = xmlReader.GetXmlReader(xmlReader.GetEntry("en/titlename.xml"));
        var mapping = nameSerializer.Deserialize(nameReader) as StringMapping;
        Debug.Assert(mapping != null);

        Dictionary<int, string> titleNames = mapping.key.ToDictionary(key => int.Parse(key.id), key => key.name);

        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/titletag.xml"));
        var data = titleTagSerializer.Deserialize(reader) as TitleTagRoot;
        Debug.Assert(data != null);

        foreach (TitleTag title in data.key) {
            yield return (title.id, titleNames.GetValueOrDefault(title.id), title);
        }
    }

    public IEnumerable<(int Id, IDictionary<byte, List<IndividualItemDrop>>)> ParseIndividualItemDrop() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/individualitemdrop.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = individualItemDropSerializer.Deserialize(reader) as IndividualItemDropRoot;
        Debug.Assert(data != null);
        var groups = data.individualDropBox.GroupBy(individualItemDrop =>  new {individualItemDrop.individualDropBoxID, individualItemDrop.dropGroup})
            .ToDictionary(group => group.Key, group => group.ToList());
        foreach (var group in groups) {
            yield return (group.Key.individualDropBoxID, group.Value.GroupBy(drop => drop.dropGroup).
                ToDictionary(drop => drop.Key, drop => drop.ToList()));
        }
    }

    public IEnumerable<(int Id, IDictionary<byte, List<IndividualItemDrop>>)> ParseIndividualItemDropCharge() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/individualitemdrop_charge.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = individualItemDropSerializer.Deserialize(reader) as IndividualItemDropRoot;
        Debug.Assert(data != null);
        var groups = data.individualDropBox.GroupBy(dropbox =>  new {dropbox.individualDropBoxID, dropbox.dropGroup})
            .ToDictionary(group => group.Key, group => group.ToList());
        foreach (var group in groups) {
            yield return (group.Key.individualDropBoxID, group.Value.GroupBy(drop => drop.dropGroup).
                ToDictionary(drop => drop.Key, drop => drop.ToList()));
        }
    }

    public IEnumerable<(int Id, IDictionary<byte, List<IndividualItemDrop>>)> ParseIndividualItemDropEvent() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/individualitemdrop_event.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = individualItemDropSerializer.Deserialize(reader) as IndividualItemDropRoot;
        Debug.Assert(data != null);
        var groups = data.individualDropBox.GroupBy(dropbox =>  new {dropbox.individualDropBoxID, dropbox.dropGroup})
            .ToDictionary(group => group.Key, group => group.ToList());
        foreach (var group in groups) {
            yield return (group.Key.individualDropBoxID, group.Value.GroupBy(drop => drop.dropGroup).
                ToDictionary(drop => drop.Key, drop => drop.ToList()));
        }
    }

    public IEnumerable<(int Id, IDictionary<byte, List<IndividualItemDrop>>)> ParseIndividualItemDropEventNpc() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/individualitemdrop_eventnpc.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = individualItemDropSerializer.Deserialize(reader) as IndividualItemDropRoot;
        Debug.Assert(data != null);
        var groups = data.individualDropBox.GroupBy(dropbox =>  new {dropbox.individualDropBoxID, dropbox.dropGroup})
            .ToDictionary(group => group.Key, group => group.ToList());
        foreach (var group in groups) {
            yield return (group.Key.individualDropBoxID, group.Value.GroupBy(drop => drop.dropGroup).
                ToDictionary(drop => drop.Key, drop => drop.ToList()));
        }
    }

    public IEnumerable<(int Id, IDictionary<byte, List<IndividualItemDrop>>)> ParseIndividualItemDropNewGacha() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/individualitemdrop_newgacha.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = individualItemDropSerializer.Deserialize(reader) as IndividualItemDropRoot;
        Debug.Assert(data != null);
        var groups = data.individualDropBox.GroupBy(dropbox =>  new {dropbox.individualDropBoxID, dropbox.dropGroup})
            .ToDictionary(group => group.Key, group => group.ToList());
        foreach (var group in groups) {
            yield return (group.Key.individualDropBoxID, group.Value.GroupBy(drop => drop.dropGroup).
                ToDictionary(drop => drop.Key, drop => drop.ToList()));
        }
    }

    public IEnumerable<(int Id, IDictionary<byte, List<IndividualItemDrop>>)> ParseIndividualItemDropPet() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/individualitemdrop_pet.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = individualItemDropSerializer.Deserialize(reader) as IndividualItemDropRoot;
        Debug.Assert(data != null);
        var groups = data.individualDropBox.GroupBy(dropbox =>  new {dropbox.individualDropBoxID, dropbox.dropGroup})
            .ToDictionary(group => group.Key, group => group.ToList());
        foreach (var group in groups) {
            yield return (group.Key.individualDropBoxID, group.Value.GroupBy(drop => drop.dropGroup).
                ToDictionary(drop => drop.Key, drop => drop.ToList()));
        }
    }

    public IEnumerable<(int Id, IDictionary<byte, List<IndividualItemDrop>>)> ParseIndividualItemDropQuestObj() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/individualitemdrop_quest_obj.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = individualItemDropSerializer.Deserialize(reader) as IndividualItemDropRoot;
        Debug.Assert(data != null);
        var groups = data.individualDropBox.GroupBy(dropbox =>  new {dropbox.individualDropBoxID, dropbox.dropGroup})
            .ToDictionary(group => group.Key, group => group.ToList());
        foreach (var group in groups) {
            yield return (group.Key.individualDropBoxID, group.Value.GroupBy(drop => drop.dropGroup).
                ToDictionary(drop => drop.Key, drop => drop.ToList()));
        }
    }

    public IEnumerable<(int Id, IDictionary<byte, List<IndividualItemDrop>>)> ParseIndividualItemDropQuestMob() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/individualitemdrop_quest_mob.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = individualItemDropSerializer.Deserialize(reader) as IndividualItemDropRoot;
        Debug.Assert(data != null);
        var groups = data.individualDropBox.GroupBy(dropbox =>  new {dropbox.individualDropBoxID, dropbox.dropGroup})
            .ToDictionary(group => group.Key, group => group.ToList());
        foreach (var group in groups) {
            yield return (group.Key.individualDropBoxID, group.Value.GroupBy(drop => drop.dropGroup).
                ToDictionary(drop => drop.Key, drop => drop.ToList()));
        }
    }

    public IEnumerable<(int Id, IDictionary<byte, List<IndividualItemDrop>>)> ParseIndividualItemDropGacha() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/na/individualitemdrop_gacha.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = individualItemDropSerializer.Deserialize(reader) as IndividualItemDropRoot;
        Debug.Assert(data != null);
        var groups = data.individualDropBox.GroupBy(dropbox =>  new {dropbox.individualDropBoxID, dropbox.dropGroup})
            .ToDictionary(group => group.Key, group => group.ToList());
        foreach (var group in groups) {
            yield return (group.Key.individualDropBoxID, group.Value.GroupBy(drop => drop.dropGroup).
                ToDictionary(drop => drop.Key, drop => drop.ToList()));
        }
    }

    public IEnumerable<(int Id, IDictionary<byte, List<IndividualItemDrop>>)> ParseIndividualItemGearBox() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/na/individualitemdrop_gearbox.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = individualItemDropSerializer.Deserialize(reader) as IndividualItemDropRoot;
        Debug.Assert(data != null);
        var groups = data.individualDropBox.GroupBy(dropbox =>  new {dropbox.individualDropBoxID, dropbox.dropGroup})
            .ToDictionary(group => group.Key, group => group.ToList());
        foreach (var group in groups) {
            yield return (group.Key.individualDropBoxID, group.Value.GroupBy(drop => drop.dropGroup).
                ToDictionary(drop => drop.Key, drop => drop.ToList()));
        }
    }

    public IEnumerable<(int Id, GachaInfo Info)> ParseGachaInfo() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/gacha_info.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = gachaInfoSerializer.Deserialize(reader) as GachaInfoRoot;
        Debug.Assert(data != null);

        foreach (GachaInfo gachaInfo in data.randomBox) {
            yield return (gachaInfo.randomBoxID, gachaInfo);
        }
    }

    public IEnumerable<(int ShopId, ShopBeautyCoupon Item)> ParseShopBeautyCoupon() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/shop_beautycoupon.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = shopBeautyCouponSerializer.Deserialize(reader) as ShopBeautyCouponRoot;
        Debug.Assert(data != null);

        foreach (ShopBeautyCoupon coupon in data.shop) {
            yield return (coupon.shopID, coupon);
        }
    }

    public IEnumerable<(int CategoryId, MeretMarketCategory Category)> ParseMeretMarketCategory() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/na/meratmarketcategory.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = meretmarketCategorySerializer.Deserialize(reader) as MeretMarketCategoryRoot;
        Debug.Assert(data != null);

        IDictionary<int, MeretMarketCategory> categories = new Dictionary<int, MeretMarketCategory>();
        foreach (MeretMarketCategory category in data.category) {
            categories.Add(category.id, category);
        }

        // Replace any existing categories with the ones under environment.
        foreach (MeretMarketEnvironment environment in data.environment) {
            foreach (MeretMarketCategory category in environment.category) {
                categories[category.id] = category;
            }
        }

        foreach (MeretMarketCategory category in categories.Values) {
            yield return (category.id, category);
        }
    }

    public IEnumerable<(int TableId, ExpBaseTable Table)> ParseExpBaseTable() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/expbasetable.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = expBaseSerializer.Deserialize(reader) as ExpBaseRoot;
        Debug.Assert(data != null);

        foreach (ExpBaseTable table in data.table) {
            yield return (table.expTableID, table);
        }
    }

    public IEnumerable<(int Level, NextExp NextExp)> ParseNextExp() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/nextexp.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = nextExpSerializer.Deserialize(reader) as NextExpRoot;
        Debug.Assert(data != null);

        foreach (NextExp entry in data.exp) {
            yield return (entry.level, entry);
        }
    }

    public IEnumerable<(int Level, AdventureLevelAbility Ability)> ParseAdventureLevelAbility() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/adventurelevelability.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = adventureLevelAbilitySerializer.Deserialize(reader) as AdventureLevelAbilityRoot;
        Debug.Assert(data != null);

        foreach (AdventureLevelAbility entry in data.ability) {
            yield return (entry.id, entry);
        }
    }

    public IEnumerable<(int Id, AdventureLevelMission Mission)> ParseAdventureLevelMission() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/adventurelevelmission.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = adventureLevelMissionSerializer.Deserialize(reader) as AdventureLevelMissionRoot;
        Debug.Assert(data != null);

        foreach (AdventureLevelMission entry in data.mission) {
            yield return (entry.missionId, entry);
        }
    }

    public IEnumerable<(int Id, AdventureLevelReward Reward)> ParseAdventureLevelReward() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/adventurelevelreward.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = adventureLevelRewardSerializer.Deserialize(reader) as AdventureLevelRewardRoot;
        Debug.Assert(data != null);

        foreach (AdventureLevelReward entry in data.reward) {
            yield return (entry.level, entry);
        }
    }

    public IEnumerable<(int Id, UgcDesign Design)> ParseUgcDesign() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/na/ugcdesign.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = ugcDesignSerializer.Deserialize(reader) as UgcDesignRoot;
        Debug.Assert(data != null);

        foreach (UgcDesign entry in data.list) {
            yield return (entry.itemID, entry);
        }
    }

    public IEnumerable<(int Id, Banner Banner)> ParseBanner() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/na/banner.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = bannerSerializer.Deserialize(reader) as BannerRoot;
        Debug.Assert(data != null);

        foreach (Banner entry in data.banner) {
            yield return (entry.id, entry);
        }
    }

    public IEnumerable<(int Id, NameTagSymbol Symbol)> ParseNameTagSymbol() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/nametagsymbol.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = nameTagSymbolSerializer.Deserialize(reader) as NameTagSymbolRoot;
        Debug.Assert(data != null);

        foreach (NameTagSymbol entry in data.symbol) {
            yield return (entry.id, entry);
        }
    }

    public IEnumerable<(CommonExpType Type, CommonExp Exp)> ParseCommonExp() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/commonexptable.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = commonExpSerializer.Deserialize(reader) as CommonExpRoot;
        Debug.Assert(data != null);

        foreach (CommonExp entry in data.exp) {
            yield return (entry.expType, entry);
        }
    }

    public IEnumerable<(int Id, ChapterBook Book)> ParseChapterBook() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/na/chapterbook.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = chapterBookSerializer.Deserialize(reader) as ChapterBookRoot;

        Debug.Assert(data != null);

        foreach (ChapterBook entry in data.chapterbook) {
            yield return (entry.id, entry);
        }
    }

    public IEnumerable<(int Id, LearningQuest Quest)> ParseLearningQuest() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/learningquest.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = learningQuestSerializer.Deserialize(reader) as LearningQuestRoot;

        Debug.Assert(data != null);

        foreach (LearningQuest entry in data.learning) {
            yield return (entry.id, entry);
        }
    }

    public IEnumerable<(int Differential, MasteryDifferentialFactor Factor)> ParseMasteryDifferentialFactor() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/masterydifferentialfactor.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = masteryDifferentialFactorSerializer.Deserialize(reader) as MasteryDifferentialFactorRoot;

        Debug.Assert(data != null);

        foreach (MasteryDifferentialFactor entry in data.v) {
            yield return (entry.differential, entry);
        }
    }

    public IEnumerable<(int Id, RewardContent Reward)> ParseRewardContent() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/rewardcontent.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = rewardContentSerializer.Deserialize(reader) as RewardContentRoot;

        Debug.Assert(data != null);

        foreach (RewardContent entry in data.v) {
            yield return (entry.rewardID, entry);
        }
    }

    public IEnumerable<(int Id, RewardContentItem Reward)> ParseRewardContentItem() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/rewardcontentitemtable.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = rewardContentItemSerializer.Deserialize(reader) as RewardContentItemRoot;

        Debug.Assert(data != null);

        foreach (RewardContentItem entry in data.table) {
            yield return (entry.itemTableID, entry);
        }
    }

    public IEnumerable<(int Id, RewardContentExpStatic Reward)> ParseRewardContentExpStatic() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/rewardcontentexpstatictable.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = rewardContentExpStaticSerializer.Deserialize(reader) as RewardContentExpStaticRoot;

        Debug.Assert(data != null);

        foreach (RewardContentExpStatic entry in data.table) {
            yield return (entry.expTableID, entry);
        }
    }

    public IEnumerable<(int Id, RewardContentMeso Reward)> ParseRewardContentMeso() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/rewardcontentmesotable.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = rewardContentMesoSerializer.Deserialize(reader) as RewardContentMesoRoot;

        Debug.Assert(data != null);

        foreach (RewardContentMeso entry in data.table) {
            yield return (entry.mesoTableID, entry);
        }
    }

    public IEnumerable<(int Id, RewardContentMesoStatic Reward)> ParseRewardContentMesoStatic() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/rewardcontentmesostatictable.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = rewardContentMesoStaticSerializer.Deserialize(reader) as RewardContentMesoStaticRoot;

        Debug.Assert(data != null);

        foreach (RewardContentMesoStatic entry in data.table) {
            yield return (entry.mesoTableID, entry);
        }
    }

    public IEnumerable<(int Level, SurvivalLevel Entry)> ParseSurvivalLevel() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/na/survivallevel.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = survivalLevelSerializer.Deserialize(reader) as SurvivalLevelRoot;

        Debug.Assert(data != null);

        foreach (SurvivalLevel entry in data.survivalLevelExp) {
            yield return (entry.level, entry);
        }
    }

    public IEnumerable<(int Level, SurvivalLevelReward Reward)> ParseSurvivalLevelReward() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/na/survivallevelreward.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = survivalLevelRewardSerializer.Deserialize(reader) as SurvivalLevelRewardRoot;

        Debug.Assert(data != null);

        foreach (SurvivalLevelReward entry in data.survivalLevelReward) {
            yield return (entry.level, entry);
        }
    }
}
