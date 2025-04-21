using Maple2.File.Parser;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Quest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class QuestParserTest {
    [TestMethod]
    public void TestQuestParser() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new QuestParser(TestUtils.XmlReader);

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
    public void TestQuestParserKr() {
        Filter.Load(TestUtilsKr.XmlReader, "KR", "Live");
        var parser = new QuestParser(TestUtilsKr.XmlReader);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.QuestSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.QuestSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, QuestDataKR data) in parser.ParseKr()) {
            // Debug.WriteLine($"Parsing Quest: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(6961, count);
    }

    [TestMethod]
    public void TestQuestDescriptionParser() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new QuestParser(TestUtils.XmlReader);

        int count = 0;
        foreach ((int id, string name) in parser.ParseQuestDescriptions()) {
            // Debug.WriteLine($"Parsing Quest Description: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(name);
            count++;
        }
        Assert.AreEqual(5612, count);
    }

    [TestMethod]
    public void TestQuestDescriptionParserKr() {
        Filter.Load(TestUtilsKr.XmlReader, "KR", "Live");
        var parser = new QuestParser(TestUtilsKr.XmlReader);

        int count = 0;
        foreach ((int id, string name) in parser.ParseQuestDescriptions()) {
            // Debug.WriteLine($"Parsing Quest Description: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(name);
            count++;
        }
        Assert.AreEqual(5793, count);
    }
}

