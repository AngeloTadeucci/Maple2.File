﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Xml.Script;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class ScriptParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer npcScriptSerializer;
    private readonly XmlSerializer questScriptSerializer;
    private readonly XmlSerializer scriptStringSerializer;

    public ScriptParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.npcScriptSerializer = new XmlSerializer(typeof(NpcScript));
        this.questScriptSerializer = new XmlSerializer(typeof(QuestScriptRoot));
        this.scriptStringSerializer = new XmlSerializer(typeof(StringMapping));
    }

    public IEnumerable<(int Id, NpcScript Script)> ParseNpc() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("script/npc"))) {
            var root = npcScriptSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as NpcScript;
            Debug.Assert(root != null);

            int npcId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name)!);
            yield return (npcId, root);
        }
    }

    public IEnumerable<QuestScript> ParseQuest() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("script/quest"))) {
            var root = questScriptSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as QuestScriptRoot;
            Debug.Assert(root != null);

            foreach (QuestScript quest in root.quest) {
                yield return quest;
            }
        }
    }

    public IDictionary<string, string> ParseStrings(string language = "en") {
        var result = new Dictionary<string, string>();
        string prefix = $"string/{language}/scriptnpc";
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith(prefix))) {
            var mapping = scriptStringSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as StringMapping;
            Debug.Assert(mapping != null);

            foreach (Key key in mapping.key) {
                result.Add(key.id, key.name);
            }
        }

        return result;
    }
}
