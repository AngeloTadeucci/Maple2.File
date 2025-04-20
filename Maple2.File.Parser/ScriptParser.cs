using System.Diagnostics;
using System.Xml.Serialization;
using M2dXmlGenerator;
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
        npcScriptSerializer = new XmlSerializer(FeatureLocaleFilter.Locale == "KR" ? typeof(NpcScriptListKR) : typeof(NpcScript));
        questScriptSerializer = new XmlSerializer(typeof(QuestScriptRoot));
        scriptStringSerializer = new XmlSerializer(typeof(StringMapping));
    }

    public IEnumerable<(int Id, NpcScript Script)> ParseNpc() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("script/npc"))) {
            var root = npcScriptSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as NpcScript;
            Debug.Assert(root != null);

            int npcId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name)!);
            yield return (npcId, root);
        }
    }

    public IEnumerable<(int Id, NpcScriptKR Script)> ParseNpcKR() {
        var entry = xmlReader.GetEntry("npcscript_final.xml");
        Debug.Assert(entry != null);
        var root = npcScriptSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as NpcScriptListKR;
        Debug.Assert(root != null);

        foreach (NpcScriptKR npc in root.npcs) {
            yield return (npc.id, npc);
        }
    }

    public IEnumerable<(int Id, QuestScript Script)> ParseQuest() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("script/quest"))) {
            var root = questScriptSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as QuestScriptRoot;
            Debug.Assert(root != null);

            foreach (QuestScript quest in root.quest) {
                yield return (quest.id, quest);
            }
        }
    }

    public IEnumerable<(int Id, QuestScript Script)> ParseQuestKR() {
        var entry = xmlReader.GetEntry("questscript_final.xml");
        Debug.Assert(entry != null);
        var root = questScriptSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as QuestScriptRoot;
        Debug.Assert(root != null);

        foreach (QuestScript quest in root.quest) {
            yield return (quest.id, quest);
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
