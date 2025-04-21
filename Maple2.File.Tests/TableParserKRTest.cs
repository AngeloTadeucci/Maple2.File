using Maple2.File.Parser;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Table;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class TableParserKrTest {
    private static TableParser _parser = null!;

    [ClassInitialize]
    public static void ClassInit(TestContext context) {
        Filter.Load(TestUtilsKr.XmlReader, "KR", "Live");
        _parser = new TableParser(TestUtilsKr.XmlReader);
    }

    [TestMethod]
    public void TestColorPaletteParserKr() {
        foreach ((_, _) in _parser.ParseColorPalette()) {
            continue;
        }

        foreach ((_, _) in _parser.ParseColorPaletteAchieve()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseScrollKr() {
        foreach ((_, _) in _parser.ParseEnchantScroll()) {
            continue;
        }
        foreach ((_, _) in _parser.ParseItemRemakeScroll()) {
            continue;
        }
        foreach ((_, _) in _parser.ParseItemRepackingScroll()) {
            continue;
        }
        foreach ((_, _) in _parser.ParseItemSocketScroll()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBankTypeKr() {
        foreach ((_, _) in _parser.ParseBankType()) {
            continue;
        }
    }

    [TestMethod]
    public void TestChatStickerKr() {
        foreach ((_, _) in _parser.ParseChatSticker()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseDefaultItemsKr() {
        foreach ((_, _, _) in _parser.ParseDefaultItems()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseDungeonRoomKr() {
        foreach ((_, _) in _parser.ParseDungeonRoom()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonRoundDataKr() {
        foreach ((_, _) in _parser.ParseDungeonRoundData()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonRankRewardKr() {
        foreach ((_, _) in _parser.ParseDungeonRankReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonMissionKr() {
        foreach ((_, _) in _parser.ParseDungeonMission()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonConfigKr() {
        foreach (var _ in _parser.ParseDungeonConfig()) {
            continue;
        }
    }

    [TestMethod]
    public void TestReverseRaidConfigKr() {
        foreach (var _ in _parser.ParseReverseRaidConfig()) {
            continue;
        }
    }

    [TestMethod]
    public void TestUnitedWeeklyRewardKr() {
        foreach (var _ in _parser.ParseUnitedWeeklyReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishKr() {
        foreach ((_, _, _) in _parser.ParseFish()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishHabitatKr() {
        foreach ((_, _) in _parser.ParseFishHabitat()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishingRodKr() {
        foreach ((_, _) in _parser.ParseFishingRod()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishingSpotKr() {
        foreach ((_, _) in _parser.ParseFishingSpot()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildBuffKr() {
        foreach ((_, _) in _parser.ParseGuildBuff()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildContributionKr() {
        foreach ((_, _) in _parser.ParseGuildContribution()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildEventKr() {
        foreach ((_, _) in _parser.ParseGuildEvent()) {
            continue;
        }
    }

    [Ignore] // Removed from KMS2?
    public void TestGuildExpKr() {
        foreach ((_, _) in _parser.ParseGuildExp()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildHouseKr() {
        foreach ((_, _) in _parser.ParseGuildHouse()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildNpcKr() {
        foreach ((_, _) in _parser.ParseGuildNpc()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildPropertyKr() {
        foreach ((_, _) in _parser.ParseGuildProperty()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseInstrumentCategoryInfoKr() {
        foreach ((_, _) in _parser.ParseInstrumentCategoryInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseInstrumentInfoKr() {
        foreach ((_, _) in _parser.ParseInstrumentInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseInteractObjectInfoKr() {
        foreach ((_, _, _) in _parser.ParseInteractObject()) {
            continue;
        }
        foreach ((_, _) in _parser.ParseInteractObjectMastery()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemBreakIngredientKr() {
        foreach ((_, _) in _parser.ParseItemBreakIngredient()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemExchangeScrollKr() {
        foreach ((_, _) in _parser.ParseItemExchangeScroll()) {
            continue;
        }
    }

    [TestMethod]
    public void TestItemExtractionKr() {
        foreach ((_, _) in _parser.ParseItemExtraction()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemGemstoneUpgradeKr() {
        foreach ((_, _) in _parser.ParseItemGemstoneUpgrade()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemLapenshardUpgradeKr() {
        foreach ((_, _) in _parser.ParseItemLapenshardUpgrade()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemSocketKr() {
        foreach ((_, _) in _parser.ParseItemSocket()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseJobTableKr() {
        Dictionary<int, List<JobTableKR>> results = _parser.ParseJobTableKR()
            .GroupBy(result => result.jobGroupID)
            .ToDictionary(group => group.Key, group => group.ToList());

        var expected = new Dictionary<int, (string, int)> {
            {1, ("", 1)},
            {10, ("", 2)},
            {20, ("", 1)},
            {30, ("", 1)},
            {40, ("", 2)},
            {50, ("", 1)},
            {60, ("", 1)},
            {70, ("", 2)},
            {80, ("", 2)},
            {90, ("", 1)},
            {100, ("", 1)},
            {110, ("", 1)},
        };
        foreach ((int jobCode, (string feature, int itemCount)) in expected) {
            Assert.IsTrue(results.TryGetValue(jobCode, out List<JobTableKR>? job));
            Assert.IsNotNull(job);
            // Ensure that FeatureLocale was filtered properly
            Assert.AreEqual(1, job.Count);
            Assert.AreEqual(job[0].Feature, feature);
            // Ensure that some value was parsed
            Assert.IsTrue(job[0].skills.skills.Count > 0);
            // Assert.IsTrue(job[0].learn.Count > 0);
            // // Ensure the right amount of items are parsed
            // Assert.AreEqual(job[0].startInvenItem.item.Count, itemCount);
            // Assert.AreEqual(job[0].reward.item.Count, itemCount);
        }
    }

    [TestMethod]
    public void TestParseMagicPathKr() {
        foreach ((_, _) in _parser.ParseMagicPath()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseMapSpawnTagKr() {
        foreach ((_, _) in _parser.ParseMapSpawnTag()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryRecipeKr() {
        foreach ((_, _) in _parser.ParseMasteryRecipe()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryRewardKr() {
        foreach ((_, _) in _parser.ParseMasteryReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePetTableKr() {
        foreach ((_, _) in _parser.ParsePetExp()) {
            continue;
        }
        foreach ((_, _) in _parser.ParsePetProperty()) {
            continue;
        }
        foreach ((_, _) in _parser.ParsePetSpawnInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePremiumClubEffectKr() {
        foreach ((_, _) in _parser.ParsePremiumClubEffect()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePremiumClubItemKr() {
        foreach ((_, _) in _parser.ParsePremiumClubItem()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePremiumClubPackageKr() {
        foreach ((_, _) in _parser.ParsePremiumClubPackage()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseSetItemInfoKr() {
        foreach ((_, _, _) in _parser.ParseSetItemInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseSetItemOptionKr() {
        int count = 0;
        foreach (var (Id, option) in _parser.ParseSetItemOptionKR()) {
            if (Id == 15123101) {
                Assert.AreEqual(2, option.part[0].count);
                Assert.AreEqual(9, option.part[0].str_value_base);
                Assert.AreEqual(4, option.part[1].count);
                Assert.AreEqual(6, option.part[1].pap_value_base);
                Assert.AreEqual(5, option.part[2].count);
                Assert.AreEqual(20, option.part[2].pen_rate_base);
            }
            count++;
        }
        Assert.AreEqual(1039, count);
    }

    [TestMethod]
    public void TestParseTitleTagKr() {
        foreach ((_, _, _) in _parser.ParseTitleTag()) {
            continue;
        }
    }

    [TestMethod]
    public void TestIndividualItemDropKr() {
        int count = 0;
        foreach ((_, _) in _parser.ParseIndividualItemDropKR()) {
            count++;
        }
        Assert.AreEqual(4625, count);
    }

    [TestMethod]
    public void TestGachaInfoKr() {
        foreach ((_, _) in _parser.ParseGachaInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestShopBeautyCouponKr() {
        foreach ((_, _) in _parser.ParseShopBeautyCoupon()) {
            continue;
        }
    }

    [TestMethod]
    public void TestShopFurnishingUgcAllKr() {
        foreach ((_, _) in _parser.ParseFurnishingShopUgcAll()) {
            continue;
        }
    }

    [TestMethod]
    public void TestShopFurnishingMaidKr() {
        foreach ((_, _) in _parser.ParseFurnishingShopMaid()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMeretMarketCategoryKr() {
        foreach ((_, _) in _parser.ParseMeretMarketCategory()) {
            continue;
        }
    }

    [TestMethod]
    public void TestExpBaseTableKr() {
        foreach ((_, _) in _parser.ParseExpBaseTable()) {
            continue;
        }
    }

    [TestMethod]
    public void TestNextExpKr() {
        foreach ((_, _) in _parser.ParseNextExp()) {
            continue;
        }
    }

    [TestMethod]
    public void TestAdventureLevelAbilityKr() {
        foreach ((_, _) in _parser.ParseAdventureLevelAbility()) {
            continue;
        }
    }

    [TestMethod]
    public void TestAdventureLevelMissionKr() {
        foreach ((_, _) in _parser.ParseAdventureLevelMission()) {
            continue;
        }
    }

    [TestMethod]
    public void TestAdventureLevelRewardKr() {
        foreach ((_, _) in _parser.ParseAdventureLevelReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestUgcDesignKr() {
        foreach ((_, _) in _parser.ParseUgcDesign()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryUgcHousingKr() {
        foreach ((_, _) in _parser.ParseMasteryUgcHousing()) {
            continue;
        }
    }

    [TestMethod]
    public void TestUgcHousingPointRewardKr() {
        foreach ((_, _) in _parser.ParseUgcHousingPointReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBannerKr() {
        foreach ((_, _) in _parser.ParseBanner()) {
            continue;
        }
    }

    [TestMethod]
    public void TestNameTagSymbolKr() {
        foreach ((_, _) in _parser.ParseNameTagSymbol()) {
            continue;
        }
    }

    [TestMethod]
    public void TestCommonExpKr() {
        foreach ((_, _) in _parser.ParseCommonExp()) {
            continue;
        }
    }

    [TestMethod]
    public void TestChapterBookKr() {
        foreach ((_, _) in _parser.ParseChapterBook()) {
            continue;
        }
    }

    [TestMethod]
    public void TestLearningQuestKr() {
        foreach ((_, _) in _parser.ParseLearningQuest()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryDifferentialFactorKr() {
        foreach ((_, _) in _parser.ParseMasteryDifferentialFactor()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentKr() {
        foreach ((_, _) in _parser.ParseRewardContent()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentItemKr() {
        foreach ((_, _) in _parser.ParseRewardContentItem()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentExpStaticKr() {
        foreach ((_, _) in _parser.ParseRewardContentExpStatic()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentMesoKr() {
        foreach ((_, _) in _parser.ParseRewardContentMeso()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentMesoStaticKr() {
        foreach ((_, _) in _parser.ParseRewardContentMesoStatic()) {
            continue;
        }
    }

    [Ignore] // Removed from KMS2
    public void TestSurvivalLevelKr() {
        foreach ((_, _) in _parser.ParseSurvivalLevel()) {
            continue;
        }
    }

    [Ignore] // Removed from KMS2
    public void TestSurvivalLevelRewardKr() {
        foreach ((_, _) in _parser.ParseSurvivalLevelReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBlackMarketStatTableKr() {
        foreach ((_, _) in _parser.ParseBlackMarketStatTable()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBlackMarketOptionKr() {
        (_, _) = _parser.ParseBlackMarketOption();
    }

    [TestMethod]
    public void TestBlackMarketCategoryKr() {
        (_, _) = _parser.ParseBlackMarketCategory();
    }

    [TestMethod]
    public void TestChangeJobKr() {
        foreach ((_, _) in _parser.ParseChangeJob()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFieldMissionKr() {
        foreach ((_, _) in _parser.ParseFieldMission()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWorldMapKr() {
        foreach ((_, _) in _parser.ParseWorldMap()) {
            continue;
        }
    }

    [Ignore] // Removed from KMS2
    public void TestMapleSurvivalSkinInfoKr() {
        foreach ((_, _) in _parser.ParseMapleSurvivalSkinInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWeddingExpKr() {
        foreach ((_, _) in _parser.ParseWeddingExp()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWeddingPackageKr() {
        foreach ((_, _) in _parser.ParseWeddingPackage()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWeddingSkillKr() {
        foreach ((_, _) in _parser.ParseWeddingSkill()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWeddingRewardKr() {
        foreach ((_, _) in _parser.ParseWeddingReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestSmartPushKr() {
        foreach ((_, _) in _parser.ParseSmartPush()) {
            continue;
        }
    }
}

