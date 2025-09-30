using Maple2.File.Parser;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class BanWordParserTest {
    [TestMethod]
    public void TestBanWordParser() {
        var locale = Locale.NA;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new BanWordParser(TestUtils.XmlReader);

        int count = 0;
        foreach ((int id, string name) in parser.ParseBanWords()) {
            Assert.IsTrue(id >= 0);
            Assert.IsFalse(string.IsNullOrEmpty(name));
            count++;
        }
        Assert.AreEqual(6179, count);
    }

    [TestMethod]
    public void TestUgcBanWordParser() {
        var locale = Locale.NA;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new BanWordParser(TestUtils.XmlReader);

        int count = 0;
        foreach ((int id, string name) in parser.ParseUgcBanWords()) {
            Assert.IsTrue(id >= 0);
            Assert.IsFalse(string.IsNullOrEmpty(name));
            count++;
        }
        Assert.AreEqual(1208, count);
    }
}
