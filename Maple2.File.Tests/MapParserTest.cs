using Maple2.File.Parser;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class MapParserTest {
    [TestMethod]
    public void TestMapParser() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new MapParser(TestUtils.XmlReader);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.MapSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.MapSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, MapData data) in parser.Parse()) {
            // Debug.WriteLine($"Parsing Map: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(1200, count);
    }

    [TestMethod]
    public void TestMapParserKR() {
        Filter.Load(TestUtilsKR.XmlReader, "KR", "Live");
        var parser = new MapParser(TestUtilsKR.XmlReader);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.MapSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.MapSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, MapData data) in parser.Parse()) {
            // Debug.WriteLine($"Parsing Map: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(1299, count);
    }
}

