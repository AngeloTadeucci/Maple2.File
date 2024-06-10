using Maple2.File.Parser;
using Maple2.File.Parser.Xml.Table;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class TableParserTest {
    [TestMethod]
    public void TestColorPaletteParser() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseColorPalette()) {
            continue;
        }

        foreach ((_, _) in parser.ParseColorPaletteAchieve()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseScroll() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseEnchantScroll()) {
            continue;
        }
        foreach ((_, _) in parser.ParseItemRemakeScroll()) {
            continue;
        }
        foreach ((_, _) in parser.ParseItemRepackingScroll()) {
            continue;
        }
        foreach ((_, _) in parser.ParseItemSocketScroll()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBankType() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseBankType()) {
            continue;
        }
    }

    [TestMethod]
    public void TestChatSticker() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseChatSticker()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseDefaultItems() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _, _) in parser.ParseDefaultItems()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseDungeonRoom() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseDungeonRoom()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonRoundData() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseDungeonRoundData()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonRankReward() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseDungeonRankReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonMission() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseDungeonMission()) {
            continue;
        }
    }

    [TestMethod]
    public void TestDungeonConfig() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach (var _ in parser.ParseDungeonConfig()) {
            continue;
        }
    }

    [TestMethod]
    public void TestReverseRaidConfig() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach (var _ in parser.ParseReverseRaidConfig()) {
            continue;
        }
    }

    [TestMethod]
    public void TestUnitedWeeklyReward() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach (var _ in parser.ParseUnitedWeeklyReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFish() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _, _) in parser.ParseFish()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishHabitat() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseFishHabitat()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishingRod() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseFishingRod()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFishingSpot() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseFishingSpot()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildBuff() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseGuildBuff()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildContribution() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseGuildContribution()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildEvent() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseGuildEvent()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildExp() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseGuildEvent()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildHouse() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseGuildHouse()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildNpc() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseGuildNpc()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGuildProperty() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseGuildProperty()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseInstrumentCategoryInfo() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseInstrumentCategoryInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseInstrumentInfo() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseInstrumentInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseInteractObjectInfo() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _, _) in parser.ParseInteractObject()) {
            continue;
        }
        foreach ((_, _) in parser.ParseInteractObjectMastery()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemBreakIngredient() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseItemBreakIngredient()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemExchangeScroll() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseItemExchangeScroll()) {
            continue;
        }
    }

    [TestMethod]
    public void TestItemExtraction() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseItemExtraction()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemGemstoneUpgrade() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseItemGemstoneUpgrade()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemLapenshardUpgrade() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseItemLapenshardUpgrade()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseItemSocket() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseItemSocket()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseJobTable() {
        var parser = new TableParser(TestUtils.XmlReader);

        Dictionary<int, List<JobTable>> results = parser.ParseJobTable()
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
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseMagicPath()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseMapSpawnTag() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseMapSpawnTag()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryRecipe() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseMasteryRecipe()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryReward() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseMasteryReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePetTable() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParsePetExp()) {
            continue;
        }
        foreach ((_, _) in parser.ParsePetProperty()) {
            continue;
        }
        foreach ((_, _) in parser.ParsePetSpawnInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePremiumClubEffect() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParsePremiumClubEffect()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePremiumClubItem() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParsePremiumClubItem()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParsePremiumClubPackage() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParsePremiumClubPackage()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseSetItemInfo() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _, _) in parser.ParseSetItemInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseSetItemOption() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseSetItemOption()) {
            continue;
        }
    }

    [TestMethod]
    public void TestParseTitleTag() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _, _) in parser.ParseTitleTag()) {
            continue;
        }
    }

    [TestMethod]
    public void TestIndividualItemDrop() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseIndividualItemDrop()) {
            continue;
        }

        foreach ((_, _) in parser.ParseIndividualItemDropCharge()) {
            continue;
        }

        foreach ((_, _) in parser.ParseIndividualItemDropEvent()) {
            continue;
        }

        foreach ((_, _) in parser.ParseIndividualItemDropEventNpc()) {
            continue;
        }

        foreach ((_, _) in parser.ParseIndividualItemDropNewGacha()) {
            continue;
        }

        foreach ((_, _) in parser.ParseIndividualItemDropPet()) {
            continue;
        }

        foreach ((_, _) in parser.ParseIndividualItemDropQuestObj()) {
            continue;
        }

        foreach ((_, _) in parser.ParseIndividualItemDropQuestMob()) {
            continue;
        }

        foreach ((_, _) in parser.ParseIndividualItemDropGacha()) {
            continue;
        }

        foreach ((_, _) in parser.ParseIndividualItemGearBox()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGachaInfo() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseGachaInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestShopBeautyCoupon() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseShopBeautyCoupon()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMeretMarketCategory() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseMeretMarketCategory()) {
            continue;
        }
    }

    [TestMethod]
    public void TestExpBaseTable() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseExpBaseTable()) {
            continue;
        }
    }

    [TestMethod]
    public void TestNextExp() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseNextExp()) {
            continue;
        }
    }

    [TestMethod]
    public void TestAdventureLevelAbility() {
        var parser = new TableParser(TestUtils.XmlReader);
        var results = parser.ParseAdventureLevelAbility();

        foreach ((_, _) in parser.ParseAdventureLevelAbility()) {
            continue;
        }
    }

    [TestMethod]
    public void TestAdventureLevelMission() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseAdventureLevelMission()) {
            continue;
        }
    }

    [TestMethod]
    public void TestAdventureLevelReward() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseAdventureLevelReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestUgcDesign() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseUgcDesign()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBanner() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseBanner()) {
            continue;
        }
    }

    [TestMethod]
    public void TestNameTagSymbol() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseNameTagSymbol()) {
            continue;
        }
    }

    [TestMethod]
    public void TestCommonExp() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseCommonExp()) {
            continue;
        }
    }

    [TestMethod]
    public void TestChapterBook() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseChapterBook()) {
            continue;
        }
    }

    [TestMethod]
    public void TestLearningQuest() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseLearningQuest()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMasteryDifferentialFactor() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseMasteryDifferentialFactor()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContent() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseRewardContent()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentItem() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseRewardContentItem()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentExpStatic() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseRewardContentExpStatic()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentMeso() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseRewardContentMeso()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRewardContentMesoStatic() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseRewardContentMesoStatic()) {
            continue;
        }
    }

    [TestMethod]
    public void TestSurvivalLevel() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseSurvivalLevel()) {
            continue;
        }
    }

    [TestMethod]
    public void TestSurvivalLevelReward() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseSurvivalLevelReward()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBlackMarketStatTable() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseBlackMarketStatTable()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBlackMarketOption() {
        var parser = new TableParser(TestUtils.XmlReader);

        (_, _) = parser.ParseBlackMarketOption();
    }

    [TestMethod]
    public void TestBlackMarketCategory() {
        var parser = new TableParser(TestUtils.XmlReader);

        (_, _) = parser.ParseBlackMarketCategory();
    }

    [TestMethod]
    public void TestChangeJob() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseChangeJob()) {
            continue;
        }
    }

    [TestMethod]
    public void TestFieldMission() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseFieldMission()) {
            continue;
        }
    }

    [TestMethod]
    public void TestWorldMap() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseWorldMap()) {
            continue;
        }
    }

    [TestMethod]
    public void TestMapleSurvivalSkinInfo() {
        var parser = new TableParser(TestUtils.XmlReader);

        foreach ((_, _) in parser.ParseMapleSurvivalSkinInfo()) {
            continue;
        }
    }
}
