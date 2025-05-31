using Maple2.File.Parser;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Table;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class TableParserNewTest {
    private static TableParser _parser = null!;

    [ClassInitialize]
    public static void ClassInit(TestContext context) {
        Filter.Load(TestUtils.XmlReader, Locale.KR.ToString(), "Live");
        _parser = new TableParser(TestUtils.XmlReader, Language.kr);
    }

    [TestMethod]
    public void TestParseJobTableNew() {
        Dictionary<int, List<JobTableNew>> results = _parser.ParseJobTableNew()
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
            Assert.IsTrue(results.TryGetValue(jobCode, out List<JobTableNew>? job));
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
    public void TestParseSetItemOptionNew() {
        int count = 0;
        foreach (var (Id, option) in _parser.ParseSetItemOptionNew()) {
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
    public void TestIndividualItemDropFinal() {
        int count = 0;
        foreach ((_, _) in _parser.ParseIndividualItemDropFinal()) {
            count++;
        }
        Assert.AreEqual(4625, count);
    }
}

