using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Table.Server;

namespace Maple2.File.Parser;

public class ServerTableParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer npcScriptConditionSerializer;
    private readonly XmlSerializer npcScriptFunctionSerializer;
    private readonly XmlSerializer questScriptConditionSerializer;
    private readonly XmlSerializer questScriptFunctionSerializer;
    private readonly XmlSerializer jobConditionSerializer;
    private readonly XmlSerializer scriptEventConditionSerializer;
    private readonly XmlSerializer userStatSerializer;
    private readonly XmlSerializer instanceFieldSerializer;
    private readonly XmlSerializer shopGameInfoSerializer;
    private readonly XmlSerializer shopGameSerializer;
    private readonly XmlSerializer shopBeautySerializer;
    private readonly XmlSerializer bonusGameSerializer;
    private readonly XmlSerializer bonusGameDropSerializer;
    private readonly XmlSerializer globalDropItemBoxSerializer;
    private readonly XmlSerializer globalDropItemSetSerializer;
    private readonly XmlSerializer individualItemDropSerializer;

    public ServerTableParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.npcScriptConditionSerializer = new XmlSerializer(typeof(NpcScriptConditionRoot));
        this.npcScriptFunctionSerializer = new XmlSerializer(typeof(NpcScriptFunctionRoot));
        this.questScriptConditionSerializer = new XmlSerializer(typeof(QuestScriptConditionRoot));
        this.questScriptFunctionSerializer = new XmlSerializer(typeof(QuestScriptFunctionRoot));
        this.jobConditionSerializer = new XmlSerializer(typeof(JobConditionTableRoot));
        this.scriptEventConditionSerializer = new XmlSerializer(typeof(ScriptEventConditionRoot));
        this.userStatSerializer = new XmlSerializer(typeof(UserStatRoot));
        this.instanceFieldSerializer = new XmlSerializer(typeof(InstanceFieldRoot));
        this.shopGameInfoSerializer = new XmlSerializer(typeof(ShopGameInfoRoot));
        this.shopGameSerializer = new XmlSerializer(typeof(ShopGameRoot));
        this.shopBeautySerializer = new XmlSerializer(typeof(ShopBeautyRoot));
        this.bonusGameSerializer = new XmlSerializer(typeof(BonusGameRoot));
        this.bonusGameDropSerializer = new XmlSerializer(typeof(BonusGameDropRoot));
        this.globalDropItemBoxSerializer = new XmlSerializer(typeof(GlobalDropItemBoxRoot));
        this.globalDropItemSetSerializer = new XmlSerializer(typeof(GlobalDropItemSetRoot));
        this.individualItemDropSerializer = new XmlSerializer(typeof(IndividualItemDropRoot));

        // var seen = new HashSet<string>();
        // this.bankTypeSerializer.UnknownAttribute += (sender, args) => {
        //     if (!seen.Contains(args.Attr.Name)) {
        //         Console.WriteLine($"Missing {args.Attr.Name}={args.Attr.Value}");
        //         seen.Add(args.Attr.Name);
        //     }
        // };
    }

    public IEnumerable<(int NpcId, IDictionary<int, NpcScriptCondition> ScriptConditions)> ParseNpcScriptCondition() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/Server/npcScriptCondition_Final.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = npcScriptConditionSerializer.Deserialize(reader) as NpcScriptConditionRoot;
        Debug.Assert(data != null);

        foreach (IGrouping<int, NpcScriptCondition> group in data.condition.GroupBy(scriptCondition => scriptCondition.npcID)) {
            yield return (group.Key, group.ToDictionary(scriptCondition => scriptCondition.scriptID));
        }
    }

    public IEnumerable<(int QuestId, IDictionary<int, QuestScriptCondition> ScriptConditions)> ParseQuestScriptCondition() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/Server/QuestScriptCondition_final.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = questScriptConditionSerializer.Deserialize(reader) as QuestScriptConditionRoot;
        Debug.Assert(data != null);

        foreach (IGrouping<int, QuestScriptCondition> group in data.condition.GroupBy(scriptCondition => scriptCondition.questID)) {
            yield return (group.Key, group.ToDictionary(scriptCondition => scriptCondition.scriptID));
        }
    }

    public IEnumerable<(int NpcId, IDictionary<int, NpcScriptFunction> ScriptFunctions)> ParseNpcScriptFunction() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/Server/npcScriptFunction_Final.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = npcScriptFunctionSerializer.Deserialize(reader) as NpcScriptFunctionRoot;
        Debug.Assert(data != null);

        foreach (IGrouping<int, NpcScriptFunction> group in data.function.GroupBy(scriptFunction => scriptFunction.npcID)) {
            yield return (group.Key, group.ToDictionary(scriptFunction => scriptFunction.scriptID));
        }
    }

    public IEnumerable<(int QuestId, IDictionary<int, QuestScriptFunction> ScriptFunctions)> ParseQuestScriptFunction() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/Server/QuestScriptFunction_final.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = questScriptFunctionSerializer.Deserialize(reader) as QuestScriptFunctionRoot;
        Debug.Assert(data != null);

        foreach (IGrouping<int, QuestScriptFunction> group in data.function.GroupBy(scriptFunction => scriptFunction.questID)) {
            yield return (group.Key, group.ToDictionary(scriptFunction => scriptFunction.scriptID));
        }
    }

    public IEnumerable<(int NpcId, JobConditionTable JobConditionTable)> ParseJobConditionTable() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/Server/jobConditionTable.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = jobConditionSerializer.Deserialize(reader) as JobConditionTableRoot;
        Debug.Assert(data != null);

        foreach (JobConditionTable jobConditionTable in data.condition) {
            yield return (jobConditionTable.npcID, jobConditionTable);
        }
    }

    public IEnumerable<(int EventId, ScriptEventCondition ScriptEventConditions)> ParseScriptEventCondition() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/Server/scriptEventCondition.xml")));
        var reader = XmlReader.Create(new StringReader(xml));
        var data = scriptEventConditionSerializer.Deserialize(reader) as ScriptEventConditionRoot;
        Debug.Assert(data != null);

        foreach (ScriptEventCondition scriptEventCondition in data.@event) {
            yield return (scriptEventCondition.id, scriptEventCondition);
        }
    }


    public IEnumerable<(short Level, UserStat UserStat)> ParseUserStat1() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/userStat1.xml"));
        var data = userStatSerializer.Deserialize(reader) as UserStatRoot;
        Debug.Assert(data != null);

        foreach (UserStat userStat in data.stat) {
            yield return (userStat.lev, userStat);
        }
    }

    public IEnumerable<(short Level, UserStat UserStat)> ParseUserStat10() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/userStat10.xml"));
        var data = userStatSerializer.Deserialize(reader) as UserStatRoot;
        Debug.Assert(data != null);

        foreach (UserStat userStat in data.stat) {
            yield return (userStat.lev, userStat);
        }
    }

    public IEnumerable<(short Level, UserStat UserStat)> ParseUserStat20() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/userStat20.xml"));
        var data = userStatSerializer.Deserialize(reader) as UserStatRoot;
        Debug.Assert(data != null);

        foreach (UserStat userStat in data.stat) {
            yield return (userStat.lev, userStat);
        }
    }

    public IEnumerable<(short Level, UserStat UserStat)> ParseUserStat30() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/userStat30.xml"));
        var data = userStatSerializer.Deserialize(reader) as UserStatRoot;
        Debug.Assert(data != null);

        foreach (UserStat userStat in data.stat) {
            yield return (userStat.lev, userStat);
        }
    }

    public IEnumerable<(short Level, UserStat UserStat)> ParseUserStat40() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/userStat40.xml"));
        var data = userStatSerializer.Deserialize(reader) as UserStatRoot;
        Debug.Assert(data != null);

        foreach (UserStat userStat in data.stat) {
            yield return (userStat.lev, userStat);
        }
    }

    public IEnumerable<(short Level, UserStat UserStat)> ParseUserStat50() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/userStat50.xml"));
        var data = userStatSerializer.Deserialize(reader) as UserStatRoot;
        Debug.Assert(data != null);

        foreach (UserStat userStat in data.stat) {
            yield return (userStat.lev, userStat);
        }
    }

    public IEnumerable<(short Level, UserStat UserStat)> ParseUserStat60() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/userStat60.xml"));
        var data = userStatSerializer.Deserialize(reader) as UserStatRoot;
        Debug.Assert(data != null);

        foreach (UserStat userStat in data.stat) {
            yield return (userStat.lev, userStat);
        }
    }

    public IEnumerable<(short Level, UserStat UserStat)> ParseUserStat70() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/userStat70.xml"));
        var data = userStatSerializer.Deserialize(reader) as UserStatRoot;
        Debug.Assert(data != null);

        foreach (UserStat userStat in data.stat) {
            yield return (userStat.lev, userStat);
        }
    }

    public IEnumerable<(short Level, UserStat UserStat)> ParseUserStat80() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/userStat80.xml"));
        var data = userStatSerializer.Deserialize(reader) as UserStatRoot;
        Debug.Assert(data != null);

        foreach (UserStat userStat in data.stat) {
            yield return (userStat.lev, userStat);
        }
    }

    public IEnumerable<(short Level, UserStat UserStat)> ParseUserStat90() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/userStat90.xml"));
        var data = userStatSerializer.Deserialize(reader) as UserStatRoot;
        Debug.Assert(data != null);

        foreach (UserStat userStat in data.stat) {
            yield return (userStat.lev, userStat);
        }
    }

    public IEnumerable<(short Level, UserStat UserStat)> ParseUserStat100() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/userStat100.xml"));
        var data = userStatSerializer.Deserialize(reader) as UserStatRoot;
        Debug.Assert(data != null);

        foreach (UserStat userStat in data.stat) {
            yield return (userStat.lev, userStat);
        }
    }

    public IEnumerable<(short Level, UserStat UserStat)> ParseUserStat110() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/userStat110.xml"));
        var data = userStatSerializer.Deserialize(reader) as UserStatRoot;
        Debug.Assert(data != null);

        foreach (UserStat userStat in data.stat) {
            yield return (userStat.lev, userStat);
        }
    }

    public IEnumerable<(short Level, UserStat UserStat)> ParseUserStat999() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/userStat999.xml"));
        var data = userStatSerializer.Deserialize(reader) as UserStatRoot;
        Debug.Assert(data != null);

        foreach (UserStat userStat in data.stat) {
            yield return (userStat.lev, userStat);
        }
    }

    public IEnumerable<(int InstanceId, InstanceField InstanceField)> ParseInstanceField() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/InstanceField.xml"));
        var data = instanceFieldSerializer.Deserialize(reader) as InstanceFieldRoot;
        Debug.Assert(data != null);

        foreach (InstanceField instanceField in data.InstanceField) {
            yield return (instanceField.instanceID, instanceField);
        }
    }

    public IEnumerable<(int ShopId, ShopGameInfo ShopGameInfo)> ParseShopGameInfo() {
        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/Server/shop_game_info.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = shopGameInfoSerializer.Deserialize(reader) as ShopGameInfoRoot;
        Debug.Assert(data != null);

        foreach (ShopGameInfo shopGameInfo in data.shop) {
            yield return (shopGameInfo.shopID, shopGameInfo);
        }
    }

    public IEnumerable<(int ShopId, ShopGame ShopGame)> ParseShopGame() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/shop_game.xml"));
        var data = shopGameSerializer.Deserialize(reader) as ShopGameRoot;
        Debug.Assert(data != null);

        foreach (ShopGame shopGame in data.shop) {
            yield return (shopGame.shopID, shopGame);
        }
    }

    public IEnumerable<(int ShopId, ShopBeauty ShopBeauty)> ParseShopBeauty() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/NA/shop_beauty.xml"));
        var data = shopBeautySerializer.Deserialize(reader) as ShopBeautyRoot;
        Debug.Assert(data != null);

        foreach (ShopBeauty shopBeauty in data.shop) {
            yield return (shopBeauty.shopID, shopBeauty);
        }
    }

    public IEnumerable<(int ShopId, ShopBeauty ShopBeauty)> ParseShopBeautyCoupon() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/shop_beautyCoupon.xml"));
        var data = shopBeautySerializer.Deserialize(reader) as ShopBeautyRoot;
        Debug.Assert(data != null);

        foreach (ShopBeauty shopBeauty in data.shop) {
            yield return (shopBeauty.shopID, shopBeauty);
        }
    }

    public IEnumerable<(int ShopId, ShopBeauty ShopBeauty)> ParseShopBeautySpecialHair() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/NA/shop_beautySpecialHair.xml"));
        var data = shopBeautySerializer.Deserialize(reader) as ShopBeautyRoot;
        Debug.Assert(data != null);

        foreach (ShopBeauty shopBeauty in data.shop) {
            yield return (shopBeauty.shopID, shopBeauty);
        }
    }

    public IEnumerable<(int GameType, int GameId, BonusGame BonusGame)> ParseBonusGame() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/BonusGame.xml"));
        var data = bonusGameSerializer.Deserialize(reader) as BonusGameRoot;
        Debug.Assert(data != null);

        foreach (BonusGame bonusGame in data.game) {
            yield return (bonusGame.gameType, bonusGame.gameID, bonusGame);
        }
    }

    public IEnumerable<(int GameType, int GameId, BonusGameDrop BonusGameDrop)> ParseBonusGameDrop() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/BonusGameDrop.xml"));
        var data = bonusGameDropSerializer.Deserialize(reader) as BonusGameDropRoot;
        Debug.Assert(data != null);

        foreach (BonusGameDrop gameDrop in data.game) {
            yield return (gameDrop.gameType, gameDrop.gameID, gameDrop);
        }
    }

    public IEnumerable<(int Id, GlobalDropItemBox GlobalDropItemBox)> ParseGlobalDropItemBox() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/globalDropItemBox_Final.xml"));
        var data = globalDropItemBoxSerializer.Deserialize(reader) as GlobalDropItemBoxRoot;
        Debug.Assert(data != null);


        foreach (GlobalDropItemBox globalDrop in data.dropBox) {
            yield return (globalDrop.dropBoxID, globalDrop);
        }
    }

    public IEnumerable<(int Id, GlobalDropItemSet GlobalDropItemSet)> ParseGlobalDropItemSet() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/globalDropItemSet_Final.xml"));
        var data = globalDropItemSetSerializer.Deserialize(reader) as GlobalDropItemSetRoot;
        Debug.Assert(data != null);

        foreach (GlobalDropItemSet globalDrop in data.dropBox) {
            yield return (globalDrop.dropGroupID, globalDrop);
        }
    }

    public IEnumerable<(int Id, IndividualItemDrop IndividualItemDrop)> ParseIndividualItemDrop() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/individualItemDrop_Final.xml"));
        var data = individualItemDropSerializer.Deserialize(reader) as IndividualItemDropRoot;
        Debug.Assert(data != null);

        foreach (IndividualItemDrop individualItemDrop in data.dropBox) {
            yield return (individualItemDrop.dropGroupID, individualItemDrop);
        }
    }
}
