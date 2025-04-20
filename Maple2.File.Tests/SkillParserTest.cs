using Maple2.File.Parser;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Skill;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class SkillParserTest {
    [TestMethod]
    public void TestSkillParser() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new SkillParser(TestUtils.XmlReader);

        int count = 0;
        foreach ((int id, string name, SkillData data) in parser.Parse()) {
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(9915, count);
    }

    [TestMethod]
    public void TestSkillParserKR() {
        Filter.Load(TestUtilsKR.XmlReader, "KR", "Live");
        var parser = new SkillParser(TestUtilsKR.XmlReader);

        int count = 0;
        foreach ((int id, string name, SkillKR data) in parser.ParseKR()) {
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(9433, count);
    }


    [TestMethod]
    public void TestSkillNames() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new SkillParser(TestUtils.XmlReader);
        Dictionary<int, string> skillNames = parser.LoadSkillNames();

        Assert.AreEqual(1392, skillNames.Count);
    }

    [TestMethod]
    public void TestSkillNamesKR() {
        Filter.Load(TestUtilsKR.XmlReader, "KR", "Live");
        var parser = new SkillParser(TestUtilsKR.XmlReader);
        Dictionary<int, string> skillNames = parser.LoadSkillNames();

        Assert.AreEqual(1421, skillNames.Count);
    }
}

