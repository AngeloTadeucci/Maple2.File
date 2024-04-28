using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Xml.Table.Server;

namespace Maple2.File.Parser;

public class ServerTableParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer npcScriptConditionSerializer;
    private readonly XmlSerializer npcScriptFunctionSerializer;
    private readonly XmlSerializer userStatSerializer;
    private readonly XmlSerializer instanceFieldSerializer;

    public ServerTableParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.npcScriptConditionSerializer = new XmlSerializer(typeof(NpcScriptConditionRoot));
        this.npcScriptFunctionSerializer = new XmlSerializer(typeof(NpcScriptFunctionRoot));
        this.userStatSerializer = new XmlSerializer(typeof(UserStatRoot));
        this.instanceFieldSerializer = new XmlSerializer(typeof(InstanceFieldRoot));

        // var seen = new HashSet<string>();
        // this.bankTypeSerializer.UnknownAttribute += (sender, args) => {
        //     if (!seen.Contains(args.Attr.Name)) {
        //         Console.WriteLine($"Missing {args.Attr.Name}={args.Attr.Value}");
        //         seen.Add(args.Attr.Name);
        //     }
        // };
    }

    public IEnumerable<(int NpcId, IDictionary<int, NpcScriptCondition> ScriptConditions)> ParseNpcScriptCondition() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/npcScriptCondition_Final.xml"));
        var data = npcScriptConditionSerializer.Deserialize(reader) as NpcScriptConditionRoot;
        Debug.Assert(data != null);

        foreach (IGrouping<int, NpcScriptCondition> group in data.condition.GroupBy(scriptCondition => scriptCondition.npcID)) {
            yield return (group.Key, group.ToDictionary(scriptCondition => scriptCondition.scriptID));
        }
    }

    public IEnumerable<(int NpcId, IDictionary<int, NpcScriptFunction> ScriptFunctions)> ParseNpcScriptFunction() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/npcScriptFunction_Final.xml"));
        var data = npcScriptFunctionSerializer.Deserialize(reader) as NpcScriptFunctionRoot;
        Debug.Assert(data != null);

        foreach (IGrouping<int, NpcScriptFunction> group in data.function.GroupBy(scriptFunction => scriptFunction.npcID)) {
            yield return (group.Key, group.ToDictionary(scriptFunction => scriptFunction.scriptID));
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
}
