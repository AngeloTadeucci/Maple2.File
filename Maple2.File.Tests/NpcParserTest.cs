using Maple2.File.Parser;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Npc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class NpcParserTest {
    [TestMethod]
    public void TestNpcParser() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new NpcParser(TestUtils.XmlReader);

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
    public void TestNpcParserKr() {
        Filter.Load(TestUtilsKr.XmlReader, "KR", "Live");
        var parser = new NpcParser(TestUtilsKr.XmlReader);

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.NpcSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NpcSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, NpcDataKR data, List<EffectDummy> dummy) in parser.ParseKr()) {
            // Debug.WriteLine($"Parsing Npc: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(10795, count);
    }

    [TestMethod]
    public void TestNpcNameParser() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new NpcParser(TestUtils.XmlReader);

        int count = 0;
        foreach ((int id, string name) in parser.ParseNpcNames()) {
            // Debug.WriteLine($"Parsing Npc Name: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(name);
            count++;
        }
        Assert.AreEqual(7114, count);
    }

    [TestMethod]
    public void TestNpcNameParserKr() {
        Filter.Load(TestUtilsKr.XmlReader, "KR", "Live");
        var parser = new NpcParser(TestUtilsKr.XmlReader);

        int count = 0;
        foreach ((int id, string name) in parser.ParseNpcNames()) {
            // Debug.WriteLine($"Parsing Npc Name: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(name);
            count++;
        }
        Assert.AreEqual(7850, count);
    }
}

