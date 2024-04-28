using Maple2.File.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class ServerTableParserTest {
    [TestMethod]
    public void TestNpcScriptCondition() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseNpcScriptCondition()) {
            continue;
        }
    }
    
    [TestMethod]
    public void TestNpcScriptFunction() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseNpcScriptFunction()) {
            continue;
        }
    }
}
