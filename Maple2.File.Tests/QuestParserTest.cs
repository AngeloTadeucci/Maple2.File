using Maple2.File.Parser;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Quest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class QuestParserTest {
    [TestMethod]
    public void TestQuestParser() {
        var locale = Locale.NA;
        var language = Language.en;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new QuestParser(TestUtils.XmlReader, language);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.QuestSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.QuestSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, QuestData data) in parser.Parse()) {
            // Debug.WriteLine($"Parsing Quest: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(4903, count);
    }

    [TestMethod]
    public void TestQuestParserNew() {
        var locale = Locale.KR;
        var language = Language.kr;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new QuestParser(TestUtils.XmlReader, language);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.QuestSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.QuestSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, QuestDataNew data) in parser.ParseNew()) {
            // Debug.WriteLine($"Parsing Quest: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(6961, count);
    }

    [TestMethod]
    public void TestQuestDescriptionParser() {
        var locale = Locale.NA;
        var language = Language.en;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new QuestParser(TestUtils.XmlReader, language);

        int count = 0;
        foreach ((int id, string name) in parser.ParseQuestDescriptions()) {
            // Debug.WriteLine($"Parsing Quest Description: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(name);
            count++;
        }
        switch (language) {
            case Language.en:
                Assert.AreEqual(5612, count);
                break;
            case Language.kr:
                Assert.AreEqual(5793, count);
                break;
        }
    }
}

