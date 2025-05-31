using Maple2.File.Parser;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Script;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class ScriptParserTest {
    [TestMethod]
    public void TestNpcScriptParser() {
        var locale = Locale.NA;
        var language = Language.en;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new ScriptParser(TestUtils.XmlReader, language);

        // parser.scriptStringSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.scriptStringSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.npcScriptSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.npcScriptSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, NpcScript script) in parser.ParseNpc()) {
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(script);
            count++;
        }
        Assert.AreEqual(3352, count);
    }

    [TestMethod]
    public void TestQuestScriptParser() {
        var locale = Locale.NA;
        var language = Language.en;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new ScriptParser(TestUtils.XmlReader, language);

        // parser.scriptStringSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.scriptStringSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.questScriptSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.questScriptSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, QuestScript script) in parser.ParseQuest()) {
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(script);
            count++;
        }
        Assert.AreEqual(4210, count);
    }

    [TestMethod]
    public void TestStringsParser() {
        var locale = Locale.NA;
        var language = Language.en;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new ScriptParser(TestUtils.XmlReader, language);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.NpcSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NpcSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((string key, string value) in parser.ParseStrings()) {
            Assert.IsNotNull(key);
            Assert.IsNotNull(value);
            count++;
        }
        Assert.AreEqual(20124, count);
    }


    [TestMethod]
    public void TestNpcScriptParserNew() {
        var locale = Locale.KR;
        var language = Language.kr;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new ScriptParser(TestUtils.XmlReader, language);

        int count = 0;
        foreach ((int id, NpcScriptNew script) in parser.ParseNpcNew()) {
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(script);
            count++;
        }
        Assert.AreEqual(3271, count);
    }

    [TestMethod]
    public void TestQuestScriptParserNew() {
        var locale = Locale.KR;
        var language = Language.kr;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new ScriptParser(TestUtils.XmlReader, language);

        int count = 0;
        foreach ((int id, QuestScript script) in parser.ParseQuestNew()) {
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(script);
            count++;
        }
        Assert.AreEqual(4291, count);
    }
}

