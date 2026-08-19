using Maple2.File.Parser;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class MapParserTest {
    [TestMethod]
    public void TestMapParser() {
        var locale = Locale.NA;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new MapParser(TestUtils.XmlReader, "en");

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.MapSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.MapSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, MapData data, MapXBlockDataRoot? xblock) in parser.Parse()) {
            // Debug.WriteLine($"Parsing Map: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(1200, count);
    }

    [TestMethod]
    public void TestMapParserNew() {
        var locale = Locale.KR;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new MapParser(TestUtils.XmlReader, "kr");

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.MapSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.MapSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, MapData data) in parser.ParseNew()) {
            // Debug.WriteLine($"Parsing Map: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(1299, count);
    }

    [TestMethod]
    public void TestParseXBlocks() {
        var locale = Locale.NA;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new MapParser(TestUtils.XmlReader, "en");

        Dictionary<string, MapXBlockDataRoot> xblocks = parser.ParseXBlocks();

        Assert.IsTrue(xblocks.Count > 0, "Expected at least one xblock");

        // Tria's xblock is known to declare fog + clientProperty.bgDay in every branch;
        // if this fails, either the archive layout changed or the deserializer regressed.
        Assert.IsTrue(xblocks.TryGetValue("02000001_tw_tria", out MapXBlockDataRoot? tria),
            "Tria xblock not found under expected key");
        Assert.IsNotNull(tria.clientProperty);
        Assert.AreEqual("BG_Tria.dds", tria.clientProperty.bgDay);
        Assert.IsNotNull(tria.fog);
    }

    [TestMethod]
    public void TestMapNames() {
        var locale = Locale.NA;
        string language = "en";
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new MapParser(TestUtils.XmlReader, language);
        var mapNames = parser.ParseMapNames();

        switch (language) {
            case "en":
                Assert.AreEqual(1152, mapNames.Count);
                break;
            case "kr":
                Assert.AreEqual(1282, mapNames.Count);
                break;
        }
    }
}

