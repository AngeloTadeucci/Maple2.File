using Maple2.File.Parser;
using Maple2.File.Parser.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class ItemOptionParserTest {
    [TestMethod]
    public void TestItemOptionParser() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new ItemOptionParser(TestUtils.XmlReader);

        foreach (var data in parser.ParseConstant()) {
            Assert.IsNotNull(data);
        }
        foreach (var data in parser.ParseRandom()) {
            Assert.IsNotNull(data);
        }
        foreach (var data in parser.ParseStatic()) {
            Assert.IsNotNull(data);
        }
    }

    [TestMethod]
    public void TestItemMergeOptionParser() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new ItemOptionParser(TestUtils.XmlReader);

        foreach (var data in parser.ParseMergeOptionBase()) {
            Assert.IsNotNull(data);
        }
        foreach (var data in parser.ParseMergeOptionMaterial()) {
            Assert.IsNotNull(data);
        }
    }

    [TestMethod]
    public void TestItemOptionPickParser() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new ItemOptionParser(TestUtils.XmlReader);

        foreach (var data in parser.ParsePick()) {
            Assert.IsNotNull(data);
        }
    }

    [TestMethod]
    public void TestItemOptionVariationParser() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new ItemOptionParser(TestUtils.XmlReader);

        foreach (var data in parser.ParseVariation()) {
            Assert.IsNotNull(data);
        }
        foreach (var data in parser.ParseVariationEquip()) {
            Assert.IsNotNull(data.Option);
        }
    }

    [TestMethod]
    public void TestItemOptionParserKr() {
        Filter.Load(TestUtilsKr.XmlReader, "KR", "Live");
        var parser = new ItemOptionParser(TestUtilsKr.XmlReader);

        int count = 0;
        foreach (var data in parser.ParseConstantKr()) {
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(4013, count);

        count = 0;
        foreach (var data in parser.ParseRandomKr()) {
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(500, count);

        // doesnt exist in kms2?
        // foreach (var data in parser.ParseStatic()) {
        //     Assert.IsNotNull(data);
        // }
    }

    [TestMethod]
    public void TestItemMergeOptionParserKr() {
        Filter.Load(TestUtilsKr.XmlReader, "KR", "Live");
        var parser = new ItemOptionParser(TestUtilsKr.XmlReader);

        int count = 0;
        foreach (var data in parser.ParseMergeOptionBaseKr()) {
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(42, count);
    }

    // [TestMethod] // Moved to constant
    // public void TestItemOptionPickParserKR() {
    //     var parser = new ItemOptionParser(TestUtilsKR.XmlReader);

    //     foreach (var data in parser.ParsePick()) {
    //         Assert.IsNotNull(data);
    //     }
    // }

    [TestMethod]
    public void TestItemOptionVariationParserKr() {
        Filter.Load(TestUtilsKr.XmlReader, "KR", "Live");
        var parser = new ItemOptionParser(TestUtilsKr.XmlReader);

        foreach (var data in parser.ParseVariation()) {
            Assert.IsNotNull(data);
        }
        foreach (var data in parser.ParseVariationEquip()) {
            Assert.IsNotNull(data.Option);
        }
    }
}

