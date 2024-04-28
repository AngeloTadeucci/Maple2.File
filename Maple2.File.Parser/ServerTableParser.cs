using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Xml.Table.Server;

namespace Maple2.File.Parser;

public class ServerTableParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer npcScriptConditionSerializer;
    private readonly XmlSerializer npcScriptFunctionSerializer;

    public ServerTableParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.npcScriptConditionSerializer = new XmlSerializer(typeof(NpcScriptConditionRoot));
        this.npcScriptFunctionSerializer = new XmlSerializer(typeof(NpcScriptFunctionRoot));

        // var seen = new HashSet<string>();
        // this.bankTypeSerializer.UnknownAttribute += (sender, args) => {
        //     if (!seen.Contains(args.Attr.Name)) {
        //         Console.WriteLine($"Missing {args.Attr.Name}={args.Attr.Value}");
        //         seen.Add(args.Attr.Name);
        //     }
        // };
    }

    public IEnumerable<(int NpcId, int ScriptID, NpcScriptCondition ScriptCondition)> ParseNpcScriptCondition() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/npcScriptCondition_Final.xml"));
        var data = npcScriptConditionSerializer.Deserialize(reader) as NpcScriptConditionRoot;
        Debug.Assert(data != null);

        foreach (NpcScriptCondition scriptCondition in data.condition) {
            yield return (scriptCondition.npcID, scriptCondition.scriptID, scriptCondition);
        }
    }
    
    public IEnumerable<(int NpcId, int ScriptId, NpcScriptFunction ScriptFunction)> ParseNpcScriptFunction() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("table/Server/npcScriptFunction_Final.xml"));
        var data = npcScriptFunctionSerializer.Deserialize(reader) as NpcScriptFunctionRoot;
        Debug.Assert(data != null);

        foreach (NpcScriptFunction scriptFunction in data.function) {
            yield return (scriptFunction.npcID, scriptFunction.scriptID, scriptFunction);
        }
    }
}
