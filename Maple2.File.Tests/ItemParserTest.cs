using Maple2.File.Parser;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Item;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class ItemParserTest {
    [TestMethod]
    public void TestItemParser() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new ItemParser(TestUtils.XmlReader);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.ItemSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.ItemSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, ItemData data) in parser.Parse<ItemDataRoot>()) {
            // Debug.WriteLine($"Parsing item: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);

            count++;
        }
        Assert.AreEqual(35309, count);
    }

    [TestMethod]
    public void TestItemParserKr() {
        Filter.Load(TestUtilsKr.XmlReader, "KR", "Live");
        var parser = new ItemParser(TestUtilsKr.XmlReader);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.ItemSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.ItemSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, ItemData data) in parser.Parse<ItemDataKR>()) {
            // Debug.WriteLine($"Parsing item: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(35970, count);
    }

    [TestMethod]
    public void TestItemNames() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new ItemParser(TestUtils.XmlReader);
        var itemNames = parser.ItemNames();

        Assert.AreEqual(34038, itemNames.Count);
    }

    [TestMethod]
    public void TestItemNamesKr() {
        Filter.Load(TestUtilsKr.XmlReader, "KR", "Live");
        var parser = new ItemParser(TestUtilsKr.XmlReader);
        var itemNames = parser.ItemNames();

        Assert.AreEqual(34273, itemNames.Count);
    }
}

