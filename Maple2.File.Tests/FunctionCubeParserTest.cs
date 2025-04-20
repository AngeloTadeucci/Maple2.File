using Maple2.File.Parser;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Object;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class FunctionCubeParserTest {
    [TestMethod]
    public void TestFunctionCubeParser() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new FunctionCubeParser(TestUtils.XmlReader);

        // parser.FunctionCubeSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.FunctionCubeSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, FunctionCubeRoot data) in parser.Parse()) {
            Assert.IsTrue(id >= 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(427, count);
    }

    [TestMethod]
    public void TestFunctionCubeParserKR() {
        Filter.Load(TestUtilsKR.XmlReader, "KR", "Live");
        var parser = new FunctionCubeParser(TestUtilsKR.XmlReader);

        int count = 0;
        foreach ((int id, FunctionCubeRoot data) in parser.Parse()) {
            Assert.IsTrue(id >= 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(433, count);
    }
}

