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
    public void TestQuestScriptCondition() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseQuestScriptCondition()) {
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
    public void TestQuestScriptFunction() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseQuestScriptFunction()) {
            continue;
        }
    }

    [TestMethod]
    public void TestJobConditionTable() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseJobConditionTable()) {
            continue;
        }
    }

    [TestMethod]
    public void TestScriptEventCondition() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseScriptEventCondition()) {
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

    [TestMethod]
    public void TestShopGameInfo() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseShopGameInfo()) {
            continue;
        }
    }

    [TestMethod]
    public void TestShopGame() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseShopGame()) {
            continue;
        }
    }

    [TestMethod]
    public void TestShopBeauty() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseShopBeauty()) {
            continue;
        }
    }

    [TestMethod]
    public void TestShopBeautyCoupon() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseShopBeautyCoupon()) {
            continue;
        }
    }

    [TestMethod]
    public void TestShopBeautySpecialHair() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseShopBeautySpecialHair()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBonusGame() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _, _) in parser.ParseBonusGame()) {
            continue;
        }
    }

    [TestMethod]
    public void TestBonusGameDrop() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _, _) in parser.ParseBonusGameDrop()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGlobalDropItemBox() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseGlobalDropItemBox()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGlobalDropItemSet() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseGlobalDropItemSet()) {
            continue;
        }
    }

    [TestMethod]
    public void TestIndividualItemDrop() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseIndividualItemDrop()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRoom() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseRoom()) {
            continue;
        }
    }

    [TestMethod]
    public void TestRandomRoom() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseRoomRandom()) {
            continue;
        }
    }

    [TestMethod]
    public void TestSpawnNpc() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseSpawnNpc()) {
            continue;
        }
    }

    [TestMethod]
    public void TestGroupSpawn() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseGroupSpawn()) {
            continue;
        }
    }

    [TestMethod]
    public void TestSpawnInteractObject() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseSpawnInteractObject()) {
            continue;
        }
    }

    [TestMethod]
    public void TestSpawnGroup() {
        var parser = new ServerTableParser(TestUtils.ServerReader);

        foreach ((_, _) in parser.ParseSpawnGroup()) {
            continue;
        }
    }
}
