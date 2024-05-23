using Maple2.File.Parser;
using Maple2.File.Parser.Xml.Object;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class FunctionCubeParserTest {
    [TestMethod]
    public void TestFunctionCubeParser() {
        var parser = new FunctionCubeParser(TestUtils.XmlReader);

        // parser.FunctionCubeSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.FunctionCubeSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        foreach ((int id, FunctionCube data) in parser.Parse()) {
            Assert.IsTrue(id >= 0);
            Assert.IsNotNull(data);
        }
    }
}
