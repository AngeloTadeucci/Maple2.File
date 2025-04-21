using Maple2.File.Parser;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Table;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class TableParserTest {
    private static TableParser _parser = null!;

    [ClassInitialize]
    public static void ClassInit(TestContext context) {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        _parser = new TableParser(TestUtils.XmlReader);
    }


    [TestMethod]
    public void TestColorPaletteParser() {
        foreach ((_, _) in _parser.ParseColorPalette()) {
            continue;
        }

        foreach ((_, _) in _parser.ParseColorPaletteAchieve()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseScroll() {
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
    public void TestBankType() {
        foreach ((_, _) in _parser.ParseBankType()) {
            continue;
        }
    }

    [TestMethod]
    public void TestChatSticker() {
        foreach ((_, _) in _parser.ParseChatSticker()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseDefaultItems() {
        foreach ((_, _, _) in _parser.ParseDefaultItems()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseDungeonRoom() {
        foreach ((_, _) in _parser.ParseDungeonRoom()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonRoundData() {
        foreach ((_, _) in _parser.ParseDungeonRoundData()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonRankReward() {
        foreach ((_, _) in _parser.ParseDungeonRankReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonMission() {
        foreach ((_, _) in _parser.ParseDungeonMission()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonConfig() {
        foreach (var _ in _parser.ParseDungeonConfig()) {
            continue;
        }
    }

    [TestMethod]
    public void TestReverseRaidConfig() {
        foreach (var _ in _parser.ParseReverseRaidConfig()) {
            continue;
        }
    }

    [TestMethod]
    public void TestUnitedWeeklyReward() {
        foreach (var _ in _parser.ParseUnitedWeeklyReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFish() {
        foreach ((_, _, _) in _parser.ParseFish()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishHabitat() {
        foreach ((_, _) in _parser.ParseFishHabitat()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishingRod() {
        foreach ((_, _) in _parser.ParseFishingRod()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishingSpot() {
        foreach ((_, _) in _parser.ParseFishingSpot()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildBuff() {
        foreach ((_, _) in _parser.ParseGuildBuff()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildContribution() {
        foreach ((_, _) in _parser.ParseGuildContribution()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildEvent() {
        foreach ((_, _) in _parser.ParseGuildEvent()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildExp() {
        foreach ((_, _) in _parser.ParseGuildEvent()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildHouse() {
        foreach ((_, _) in _parser.ParseGuildHouse()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildNpc() {
        foreach ((_, _) in _parser.ParseGuildNpc()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildProperty() {
        foreach ((_, _) in _parser.ParseGuildProperty()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseInstrumentCategoryInfo() {
        foreach ((_, _) in _parser.ParseInstrumentCategoryInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseInstrumentInfo() {
        foreach ((_, _) in _parser.ParseInstrumentInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseInteractObjectInfo() {
        foreach ((_, _, _) in _parser.ParseInteractObject()) {
            continue;
        }
        foreach ((_, _) in _parser.ParseInteractObjectMastery()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemBreakIngredient() {
        foreach ((_, _) in _parser.ParseItemBreakIngredient()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemExchangeScroll() {
        foreach ((_, _) in _parser.ParseItemExchangeScroll()) {
            continue;
        }
    }

    [TestMethod]
    public void TestItemExtraction() {
        foreach ((_, _) in _parser.ParseItemExtraction()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemGemstoneUpgrade() {
        foreach ((_, _) in _parser.ParseItemGemstoneUpgrade()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemLapenshardUpgrade() {
        foreach ((_, _) in _parser.ParseItemLapenshardUpgrade()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemSocket() {
        foreach ((_, _) in _parser.ParseItemSocket()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseJobTable() {
        Dictionary<int, List<JobTable>> results = _parser.ParseJobTable()
            .GroupBy(result => result.code)
            .ToDictionary(group => group.Key, group => group.ToList());

        var expected = new Dictionary<int, (string, int)> {
            {1, ("", 1)},
            {10, ("JobChange_02", 2)},
            {20, ("JobChange_02", 1)},
            {30, ("JobChange_02", 1)},
            {40, ("JobChange_02", 2)},
            {50, ("JobChange_02", 1)},
            {60, ("JobChange_02", 1)},
            {70, ("JobChange_02", 2)},
            {80, ("JobChange_02", 2)},
            {90, ("JobChange_02", 1)},
            {100, ("JobChange_02", 1)},
            {110, ("JobChange_02", 1)},
        };
        foreach ((int jobCode, (string feature, int itemCount)) in expected) {
            Assert.IsTrue(results.TryGetValue(jobCode, out List<JobTable>? job));
            Assert.IsNotNull(job);
            // Ensure that FeatureLocale was filtered properly
            Assert.AreEqual(1, job.Count);
            Assert.AreEqual(job[0].Feature, feature);
            // Ensure that some value was parsed
            Assert.IsTrue(job[0].skills.skill.Count > 0);
            Assert.IsTrue(job[0].learn.Count > 0);
            // Ensure the right amount of items are parsed
            Assert.AreEqual(job[0].startInvenItem.item.Count, itemCount);
            Assert.AreEqual(job[0].reward.item.Count, itemCount);
        }
    }

    [TestMethod]
    public void TestParseMagicPath() {
        foreach ((_, _) in _parser.ParseMagicPath()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseMapSpawnTag() {
        foreach ((_, _) in _parser.ParseMapSpawnTag()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryRecipe() {
        foreach ((_, _) in _parser.ParseMasteryRecipe()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryReward() {
        foreach ((_, _) in _parser.ParseMasteryReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePetTable() {
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
    public void TestParsePremiumClubEffect() {
        foreach ((_, _) in _parser.ParsePremiumClubEffect()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePremiumClubItem() {
        foreach ((_, _) in _parser.ParsePremiumClubItem()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePremiumClubPackage() {
        foreach ((_, _) in _parser.ParsePremiumClubPackage()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseSetItemInfo() {
        foreach ((_, _, _) in _parser.ParseSetItemInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseSetItemOption() {
        foreach ((_, _) in _parser.ParseSetItemOption()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseTitleTag() {
        foreach ((_, _, _) in _parser.ParseTitleTag()) {
            continue;
        }
    }

    [TestMethod]
    public void TestIndividualItemDrop() {
        foreach ((_, _) in _parser.ParseIndividualItemDrop()) {
            continue;
        }

        foreach ((_, _) in _parser.ParseIndividualItemDropCharge()) {
            continue;
        }

        foreach ((_, _) in _parser.ParseIndividualItemDropEvent()) {
            continue;
        }

        foreach ((_, _) in _parser.ParseIndividualItemDropEventNpc()) {
            continue;
        }

        foreach ((_, _) in _parser.ParseIndividualItemDropNewGacha()) {
            continue;
        }

        foreach ((_, _) in _parser.ParseIndividualItemDropPet()) {
            continue;
        }

        foreach ((_, _) in _parser.ParseIndividualItemDropQuestObj()) {
            continue;
        }

        foreach ((_, _) in _parser.ParseIndividualItemDropQuestMob()) {
            continue;
        }

        foreach ((_, _) in _parser.ParseIndividualItemDropGacha()) {
            continue;
        }

        foreach ((_, _) in _parser.ParseIndividualItemGearBox()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGachaInfo() {
        foreach ((_, _) in _parser.ParseGachaInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestShopBeautyCoupon() {
        foreach ((_, _) in _parser.ParseShopBeautyCoupon()) {
            continue;
        }
    }

    [TestMethod]
    public void TestShopFurnishingUgcAll() {
        foreach ((_, _) in _parser.ParseFurnishingShopUgcAll()) {
            continue;
        }
    }

    [TestMethod]
    public void TestShopFurnishingMaid() {
        foreach ((_, _) in _parser.ParseFurnishingShopMaid()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMeretMarketCategory() {
        foreach ((_, _) in _parser.ParseMeretMarketCategory()) {
            continue;
        }
    }

    [TestMethod]
    public void TestExpBaseTable() {
        foreach ((_, _) in _parser.ParseExpBaseTable()) {
            continue;
        }
    }

    [TestMethod]
    public void TestNextExp() {
        foreach ((_, _) in _parser.ParseNextExp()) {
            continue;
        }
    }

    [TestMethod]
    public void TestAdventureLevelAbility() {
        foreach ((_, _) in _parser.ParseAdventureLevelAbility()) {
            continue;
        }
    }

    [TestMethod]
    public void TestAdventureLevelMission() {
        foreach ((_, _) in _parser.ParseAdventureLevelMission()) {
            continue;
        }
    }

    [TestMethod]
    public void TestAdventureLevelReward() {
        foreach ((_, _) in _parser.ParseAdventureLevelReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestUgcDesign() {
        foreach ((_, _) in _parser.ParseUgcDesign()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryUgcHousing() {
        foreach ((_, _) in _parser.ParseMasteryUgcHousing()) {
            continue;
        }
    }

    [TestMethod]
    public void TestUgcHousingPointReward() {
        foreach ((_, _) in _parser.ParseUgcHousingPointReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBanner() {
        foreach ((_, _) in _parser.ParseBanner()) {
            continue;
        }
    }

    [TestMethod]
    public void TestNameTagSymbol() {
        foreach ((_, _) in _parser.ParseNameTagSymbol()) {
            continue;
        }
    }

    [TestMethod]
    public void TestCommonExp() {
        foreach ((_, _) in _parser.ParseCommonExp()) {
            continue;
        }
    }

    [TestMethod]
    public void TestChapterBook() {
        foreach ((_, _) in _parser.ParseChapterBook()) {
            continue;
        }
    }

    [TestMethod]
    public void TestLearningQuest() {
        foreach ((_, _) in _parser.ParseLearningQuest()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryDifferentialFactor() {
        foreach ((_, _) in _parser.ParseMasteryDifferentialFactor()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContent() {
        foreach ((_, _) in _parser.ParseRewardContent()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentItem() {
        foreach ((_, _) in _parser.ParseRewardContentItem()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentExpStatic() {
        foreach ((_, _) in _parser.ParseRewardContentExpStatic()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentMeso() {
        foreach ((_, _) in _parser.ParseRewardContentMeso()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentMesoStatic() {
        foreach ((_, _) in _parser.ParseRewardContentMesoStatic()) {
            continue;
        }
    }

    [TestMethod]
    public void TestSurvivalLevel() {
        foreach ((_, _) in _parser.ParseSurvivalLevel()) {
            continue;
        }
    }

    [TestMethod]
    public void TestSurvivalLevelReward() {
        foreach ((_, _) in _parser.ParseSurvivalLevelReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBlackMarketStatTable() {
        foreach ((_, _) in _parser.ParseBlackMarketStatTable()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBlackMarketOption() {
        (_, _) = _parser.ParseBlackMarketOption();
    }

    [TestMethod]
    public void TestBlackMarketCategory() {
        (_, _) = _parser.ParseBlackMarketCategory();
    }

    [TestMethod]
    public void TestChangeJob() {
        foreach ((_, _) in _parser.ParseChangeJob()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFieldMission() {
        foreach ((_, _) in _parser.ParseFieldMission()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWorldMap() {
        foreach ((_, _) in _parser.ParseWorldMap()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMapleSurvivalSkinInfo() {
        foreach ((_, _) in _parser.ParseMapleSurvivalSkinInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWeddingExp() {
        foreach ((_, _) in _parser.ParseWeddingExp()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWeddingPackage() {
        foreach ((_, _) in _parser.ParseWeddingPackage()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWeddingSkill() {
        foreach ((_, _) in _parser.ParseWeddingSkill()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWeddingReward() {
        foreach ((_, _) in _parser.ParseWeddingReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestSmartPush() {
        foreach ((_, _) in _parser.ParseSmartPush()) {
            continue;
        }
    }
}

