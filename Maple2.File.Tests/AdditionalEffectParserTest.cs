using Maple2.File.Parser;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.AdditionalEffect;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class AdditionalEffectParserTest {
    [TestMethod]
    public void TestAdditionalEffectParser() {
        var locale = Locale.NA;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new AdditionalEffectParser(TestUtils.XmlReader);

        int count = 0;
        foreach ((int id, IList<AdditionalEffectData> data) in parser.Parse()) {
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(6079, count);
    }

    [TestMethod]
    public void TestAdditionalEffectParserNew() {
        var locale = Locale.KR;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new AdditionalEffectParser(TestUtils.XmlReader);

        int count = 0;
        foreach ((int id, IList<AdditionalEffectDataNew> data) in parser.ParseNew()) {
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(5881, count);
    }
}

