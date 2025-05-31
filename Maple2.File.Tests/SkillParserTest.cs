using Maple2.File.Parser;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Skill;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class SkillParserTest {
    [TestMethod]
    public void TestSkillParser() {
        var locale = Locale.NA;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new SkillParser(TestUtils.XmlReader, Language.en);

        int count = 0;
        foreach ((int id, string name, SkillData data) in parser.Parse()) {
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(9915, count);
    }

    [TestMethod]
    public void TestSkillParserNew() {
        var locale = Locale.KR;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new SkillParser(TestUtils.XmlReader, Language.kr);

        // parser.skillNewSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        //parser.skillNewSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;


        int count = 0;
        foreach ((int id, string name, SkillNew data) in parser.ParseNew()) {
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(9433, count);
    }


    [TestMethod]
    public void TestSkillNames() {
        var locale = Locale.NA;
        Filter.Load(TestUtils.XmlReader, locale.ToString(), "Live");
        var parser = new SkillParser(TestUtils.XmlReader, Language.en);
        Dictionary<int, string> skillNames = parser.LoadSkillNames();

        switch (locale) {
            case Locale.NA:
                break;
            case Locale.KR:
                break;
        }
        Assert.AreEqual(1392, skillNames.Count);
    }
}

