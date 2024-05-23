using Maple2.File.Parser;
using Maple2.File.Parser.Xml.Quest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class QuestParserTest {
    [TestMethod]
    public void TestQuestParser() {
        var parser = new QuestParser(TestUtils.XmlReader);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.QuestSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.QuestSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        foreach ((int id, string name, QuestData data) in parser.Parse()) {
            // Debug.WriteLine($"Parsing Quest: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
        }
    }
}
