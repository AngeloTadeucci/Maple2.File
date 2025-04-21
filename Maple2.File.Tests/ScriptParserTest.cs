using Maple2.File.Parser;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Script;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class ScriptParserTest {
    [TestMethod]
    public void TestNpcScriptParser() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new ScriptParser(TestUtils.XmlReader);

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
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new ScriptParser(TestUtils.XmlReader);

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
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new ScriptParser(TestUtils.XmlReader);

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
    public void TestNpcScriptParserKr() {
        Filter.Load(TestUtilsKr.XmlReader, "KR", "Live");
        var parser = new ScriptParser(TestUtilsKr.XmlReader);

        int count = 0;
        foreach ((int id, NpcScriptKR script) in parser.ParseNpcKr()) {
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(script);
            count++;
        }
        Assert.AreEqual(3271, count);
    }

    [TestMethod]
    public void TestQuestScriptParserKr() {
        Filter.Load(TestUtilsKr.XmlReader, "KR", "Live");
        var parser = new ScriptParser(TestUtilsKr.XmlReader);

        int count = 0;
        foreach ((int id, QuestScript script) in parser.ParseQuestKr()) {
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(script);
            count++;
        }
        Assert.AreEqual(4291, count);
    }
}

