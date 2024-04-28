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

    [TestMethod]
    public void TestUserStats() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseUserStat1()) {
            continue;
        }

        foreach ((_, _) in parser.ParseUserStat10()) {
            continue;
        }

        foreach ((_, _) in parser.ParseUserStat20()) {
            continue;
        }

        foreach ((_, _) in parser.ParseUserStat30()) {
            continue;
        }

        foreach ((_, _) in parser.ParseUserStat40()) {
            continue;
        }

        foreach ((_, _) in parser.ParseUserStat50()) {
            continue;
        }

        foreach ((_, _) in parser.ParseUserStat60()) {
            continue;
        }

        foreach ((_, _) in parser.ParseUserStat70()) {
            continue;
        }

        foreach ((_, _) in parser.ParseUserStat80()) {
            continue;
        }

        foreach ((_, _) in parser.ParseUserStat90()) {
            continue;
        }

        foreach ((_, _) in parser.ParseUserStat100()) {
            continue;
        }

        foreach ((_, _) in parser.ParseUserStat110()) {
            continue;
        }

        foreach ((_, _) in parser.ParseUserStat999()) {
            continue;
        }
    }

    [TestMethod]
    public void TestInstanceField() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseInstanceField()) {
            continue;
        }
    }
}
