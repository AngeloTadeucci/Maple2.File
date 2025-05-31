using Maple2.File.Parser;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Riding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class RidingParserTest {
    [TestMethod]
    public void TestRidingParser() {
        var locale = Locale.NA;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new RidingParser(TestUtils.XmlReader);

        int count = 0;
        foreach ((int id, Riding data) in parser.Parse()) {
            // Debug.WriteLine($"Parsing Riding: {id}");
            Assert.IsTrue(id >= 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(480, count);
    }

    [TestMethod]
    public void TestRidingPassengerParser() {
        var locale = Locale.NA;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new RidingParser(TestUtils.XmlReader);

        int count = 0;
        foreach ((int id, IList<PassengerRiding> data) in parser.ParsePassenger()) {
            // Debug.WriteLine($"Parsing PassengerRiding: {id}");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(29, count);
    }

    [TestMethod]
    public void TestRidingParserKr() {
        var locale = Locale.KR;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new RidingParser(TestUtils.XmlReader);

        int count = 0;
        foreach ((int id, RidingNew data) in parser.ParseNew()) {
            // Debug.WriteLine($"Parsing Riding: {id}");
            Assert.IsTrue(id >= 0);
            Assert.IsNotNull(data);
            if (data.passengers != null) {
                foreach (PassengerRiding passenger in data.passengers) {
                    Assert.IsNotNull(passenger);
                }
            }
            count++;
        }
        Assert.AreEqual(615, count);
    }
}

