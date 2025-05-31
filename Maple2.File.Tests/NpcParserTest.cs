using Maple2.File.Parser;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Npc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class NpcParserTest {
    [TestMethod]
    public void TestNpcParser() {
        var locale = Locale.NA;
        var language = Language.en;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new NpcParser(TestUtils.XmlReader, language);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.NpcSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NpcSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, NpcData data, List<EffectDummy> dummy) in parser.Parse()) {
            // Debug.WriteLine($"Parsing Npc: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(7535, count);
    }

    [TestMethod]
    public void TestNpcParserNew() {
        var locale = Locale.KR;
        var language = Language.kr;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new NpcParser(TestUtils.XmlReader, language);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.NpcSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NpcSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, NpcDataNew data, List<EffectDummy> dummy) in parser.ParseNew()) {
            // Debug.WriteLine($"Parsing Npc: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(10795, count);
    }

    [TestMethod]
    public void TestNpcNameParser() {
        var locale = Locale.NA;
        var language = Language.en;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new NpcParser(TestUtils.XmlReader, language);

        int count = 0;
        foreach ((int id, string name) in parser.ParseNpcNames()) {
            // Debug.WriteLine($"Parsing Npc Name: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(name);
            count++;
        }
        switch (locale) {
            case Locale.NA:
                Assert.AreEqual(7114, count);
                break;
            case Locale.KR:
                Assert.AreEqual(7850, count);
                break;
        }
    }
}

