using Maple2.File.Parser;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Riding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class RidingParserTest {
    [TestMethod]
    public void TestRidingParser() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
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
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
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
    public void TestRidingParserKR() {
        Filter.Load(TestUtilsKR.XmlReader, "KR", "Live");
        var parser = new RidingParser(TestUtilsKR.XmlReader);

        int count = 0;
        foreach ((int id, RidingKR data) in parser.ParseKR()) {
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

