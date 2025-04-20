using Maple2.File.Parser;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Table;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class TableParserKRTest {
    private static TableParser _parser = null!;

    [ClassInitialize]
    public static void ClassInit(TestContext context) {
        Filter.Load(TestUtilsKR.XmlReader, "KR", "Live");
        _parser = new TableParser(TestUtilsKR.XmlReader);
    }

    [TestMethod]
    public void TestColorPaletteParserKR() {
        foreach ((_, _) in _parser.ParseColorPalette()) {
            continue;
        }

        foreach ((_, _) in _parser.ParseColorPaletteAchieve()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseScrollKR() {
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
    public void TestBankTypeKR() {
        foreach ((_, _) in _parser.ParseBankType()) {
            continue;
        }
    }

    [TestMethod]
    public void TestChatStickerKR() {
        foreach ((_, _) in _parser.ParseChatSticker()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseDefaultItemsKR() {
        foreach ((_, _, _) in _parser.ParseDefaultItems()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseDungeonRoomKR() {
        foreach ((_, _) in _parser.ParseDungeonRoom()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonRoundDataKR() {
        foreach ((_, _) in _parser.ParseDungeonRoundData()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonRankRewardKR() {
        foreach ((_, _) in _parser.ParseDungeonRankReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonMissionKR() {
        foreach ((_, _) in _parser.ParseDungeonMission()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonConfigKR() {
        foreach (var _ in _parser.ParseDungeonConfig()) {
            continue;
        }
    }

    [TestMethod]
    public void TestReverseRaidConfigKR() {
        foreach (var _ in _parser.ParseReverseRaidConfig()) {
            continue;
        }
    }

    [TestMethod]
    public void TestUnitedWeeklyRewardKR() {
        foreach (var _ in _parser.ParseUnitedWeeklyReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishKR() {
        foreach ((_, _, _) in _parser.ParseFish()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishHabitatKR() {
        foreach ((_, _) in _parser.ParseFishHabitat()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishingRodKR() {
        foreach ((_, _) in _parser.ParseFishingRod()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishingSpotKR() {
        foreach ((_, _) in _parser.ParseFishingSpot()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildBuffKR() {
        foreach ((_, _) in _parser.ParseGuildBuff()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildContributionKR() {
        foreach ((_, _) in _parser.ParseGuildContribution()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildEventKR() {
        foreach ((_, _) in _parser.ParseGuildEvent()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildExpKR() {
        foreach ((_, _) in _parser.ParseGuildEvent()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildHouseKR() {
        foreach ((_, _) in _parser.ParseGuildHouse()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildNpcKR() {
        foreach ((_, _) in _parser.ParseGuildNpc()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildPropertyKR() {
        foreach ((_, _) in _parser.ParseGuildProperty()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseInstrumentCategoryInfoKR() {
        foreach ((_, _) in _parser.ParseInstrumentCategoryInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseInstrumentInfoKR() {
        foreach ((_, _) in _parser.ParseInstrumentInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseInteractObjectInfoKR() {
        foreach ((_, _, _) in _parser.ParseInteractObject()) {
            continue;
        }
        foreach ((_, _) in _parser.ParseInteractObjectMastery()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemBreakIngredientKR() {
        foreach ((_, _) in _parser.ParseItemBreakIngredient()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemExchangeScrollKR() {
        foreach ((_, _) in _parser.ParseItemExchangeScroll()) {
            continue;
        }
    }

    [TestMethod]
    public void TestItemExtractionKR() {
        foreach ((_, _) in _parser.ParseItemExtraction()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemGemstoneUpgradeKR() {
        foreach ((_, _) in _parser.ParseItemGemstoneUpgrade()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemLapenshardUpgradeKR() {
        foreach ((_, _) in _parser.ParseItemLapenshardUpgrade()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemSocketKR() {
        foreach ((_, _) in _parser.ParseItemSocket()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseJobTableKR() {
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
    public void TestParseMagicPathKR() {
        foreach ((_, _) in _parser.ParseMagicPath()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseMapSpawnTagKR() {
        foreach ((_, _) in _parser.ParseMapSpawnTag()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryRecipeKR() {
        foreach ((_, _) in _parser.ParseMasteryRecipe()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryRewardKR() {
        foreach ((_, _) in _parser.ParseMasteryReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePetTableKR() {
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
    public void TestParsePremiumClubEffectKR() {
        foreach ((_, _) in _parser.ParsePremiumClubEffect()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePremiumClubItemKR() {
        foreach ((_, _) in _parser.ParsePremiumClubItem()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePremiumClubPackageKR() {
        foreach ((_, _) in _parser.ParsePremiumClubPackage()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseSetItemInfoKR() {
        foreach ((_, _, _) in _parser.ParseSetItemInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseSetItemOptionKR() {
        int count = 0;
        foreach (var (Id, Option) in _parser.ParseSetItemOptionKR()) {
            if (Id == 15123101) {
                Assert.AreEqual(2, Option.part[0].count);
                Assert.AreEqual(9, Option.part[0].str_value_base);
                Assert.AreEqual(4, Option.part[1].count);
                Assert.AreEqual(6, Option.part[1].pap_value_base);
                Assert.AreEqual(5, Option.part[2].count);
                Assert.AreEqual(20, Option.part[2].pen_rate_base);
            }
            count++;
        }
        Assert.AreEqual(1039, count);
    }

    [TestMethod]
    public void TestParseTitleTagKR() {
        foreach ((_, _, _) in _parser.ParseTitleTag()) {
            continue;
        }
    }

    [TestMethod]
    public void TestIndividualItemDropKR() {
        int count = 0;
        foreach ((_, _) in _parser.ParseIndividualItemDropKR()) {
            count++;
        }
        Assert.AreEqual(4625, count);
    }

    [TestMethod]
    public void TestGachaInfoKR() {
        foreach ((_, _) in _parser.ParseGachaInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestShopBeautyCouponKR() {
        foreach ((_, _) in _parser.ParseShopBeautyCoupon()) {
            continue;
        }
    }

    [TestMethod]
    public void TestShopFurnishingUgcAllKR() {
        foreach ((_, _) in _parser.ParseFurnishingShopUgcAll()) {
            continue;
        }
    }

    [TestMethod]
    public void TestShopFurnishingMaidKR() {
        foreach ((_, _) in _parser.ParseFurnishingShopMaid()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMeretMarketCategoryKR() {
        foreach ((_, _) in _parser.ParseMeretMarketCategory()) {
            continue;
        }
    }

    [TestMethod]
    public void TestExpBaseTableKR() {
        foreach ((_, _) in _parser.ParseExpBaseTable()) {
            continue;
        }
    }

    [TestMethod]
    public void TestNextExpKR() {
        foreach ((_, _) in _parser.ParseNextExp()) {
            continue;
        }
    }

    [TestMethod]
    public void TestAdventureLevelAbilityKR() {
        var results = _parser.ParseAdventureLevelAbility();

        foreach ((_, _) in _parser.ParseAdventureLevelAbility()) {
            continue;
        }
    }

    [TestMethod]
    public void TestAdventureLevelMissionKR() {
        foreach ((_, _) in _parser.ParseAdventureLevelMission()) {
            continue;
        }
    }

    [TestMethod]
    public void TestAdventureLevelRewardKR() {
        foreach ((_, _) in _parser.ParseAdventureLevelReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestUgcDesignKR() {
        foreach ((_, _) in _parser.ParseUgcDesign()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryUgcHousingKR() {
        foreach ((_, _) in _parser.ParseMasteryUgcHousing()) {
            continue;
        }
    }

    [TestMethod]
    public void TestUgcHousingPointRewardKR() {
        foreach ((_, _) in _parser.ParseUgcHousingPointReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBannerKR() {
        foreach ((_, _) in _parser.ParseBanner()) {
            continue;
        }
    }

    [TestMethod]
    public void TestNameTagSymbolKR() {
        foreach ((_, _) in _parser.ParseNameTagSymbol()) {
            continue;
        }
    }

    [TestMethod]
    public void TestCommonExpKR() {
        foreach ((_, _) in _parser.ParseCommonExp()) {
            continue;
        }
    }

    [TestMethod]
    public void TestChapterBookKR() {
        foreach ((_, _) in _parser.ParseChapterBook()) {
            continue;
        }
    }

    [TestMethod]
    public void TestLearningQuestKR() {
        foreach ((_, _) in _parser.ParseLearningQuest()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryDifferentialFactorKR() {
        foreach ((_, _) in _parser.ParseMasteryDifferentialFactor()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentKR() {
        foreach ((_, _) in _parser.ParseRewardContent()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentItemKR() {
        foreach ((_, _) in _parser.ParseRewardContentItem()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentExpStaticKR() {
        foreach ((_, _) in _parser.ParseRewardContentExpStatic()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentMesoKR() {
        foreach ((_, _) in _parser.ParseRewardContentMeso()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentMesoStaticKR() {
        foreach ((_, _) in _parser.ParseRewardContentMesoStatic()) {
            continue;
        }
    }

    [Ignore] // Removed from KMS2
    public void TestSurvivalLevelKR() {
        foreach ((_, _) in _parser.ParseSurvivalLevel()) {
            continue;
        }
    }

    [Ignore] // Removed from KMS2
    public void TestSurvivalLevelRewardKR() {
        foreach ((_, _) in _parser.ParseSurvivalLevelReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBlackMarketStatTableKR() {
        foreach ((_, _) in _parser.ParseBlackMarketStatTable()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBlackMarketOptionKR() {
        (_, _) = _parser.ParseBlackMarketOption();
    }

    [TestMethod]
    public void TestBlackMarketCategoryKR() {
        (_, _) = _parser.ParseBlackMarketCategory();
    }

    [TestMethod]
    public void TestChangeJobKR() {
        foreach ((_, _) in _parser.ParseChangeJob()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFieldMissionKR() {
        foreach ((_, _) in _parser.ParseFieldMission()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWorldMapKR() {
        foreach ((_, _) in _parser.ParseWorldMap()) {
            continue;
        }
    }

    [Ignore] // Removed from KMS2
    public void TestMapleSurvivalSkinInfoKR() {
        foreach ((_, _) in _parser.ParseMapleSurvivalSkinInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWeddingExpKR() {
        foreach ((_, _) in _parser.ParseWeddingExp()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWeddingPackageKR() {
        foreach ((_, _) in _parser.ParseWeddingPackage()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWeddingSkillKR() {
        foreach ((_, _) in _parser.ParseWeddingSkill()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWeddingRewardKR() {
        foreach ((_, _) in _parser.ParseWeddingReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestSmartPushKR() {
        foreach ((_, _) in _parser.ParseSmartPush()) {
            continue;
        }
    }
}

