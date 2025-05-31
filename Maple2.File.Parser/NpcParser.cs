using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Npc;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class NpcParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer nameSerializer;
    private readonly XmlSerializer npcSerializer;
    private readonly XmlSerializer npcNewSerializer;
    private readonly Language language;

    public NpcParser(M2dReader xmlReader, Language language) {
        this.xmlReader = xmlReader;
        this.language = language;
        nameSerializer = new XmlSerializer(typeof(StringMapping));
        npcSerializer = new XmlSerializer(typeof(NpcDataRoot));
        npcNewSerializer = new XmlSerializer(typeof(NpcDataListNew));
    }

    public Dictionary<int, string> ParseNpcNames() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry($"{language.ToString()}/npcname.xml"));
        var npcNames = nameSerializer.Deserialize(reader) as StringMapping;
        Debug.Assert(npcNames != null);
        return npcNames.key.ToDictionary(key => int.Parse(key.id), key => key.name);
    }

    public IEnumerable<(int Id, string Name, NpcData Data, List<EffectDummy> Dummy)> Parse() {
        var npcNames = ParseNpcNames();
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("npc/"))) {
            var reader = XmlReader.Create(new StringReader(Sanitizer.SanitizeNpc(xmlReader.GetString(entry))));
            var root = npcSerializer.Deserialize(reader) as NpcDataRoot;
            Debug.Assert(root != null);

            NpcData data = root.environment;
            if (data == null) continue;

            int npcId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (npcId, npcNames.GetValueOrDefault(npcId, string.Empty), data, root.effectdummy);
        }
    }

    public IEnumerable<(int Id, string Name, NpcDataNew Data, List<EffectDummy> Dummy)> ParseNew() {
        var npcNames = ParseNpcNames();
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("npcdata/"))) {
            var reader = XmlReader.Create(new StringReader(Sanitizer.SanitizeNpc(xmlReader.GetString(entry))));
            var rootKr = npcNewSerializer.Deserialize(reader) as NpcDataListNew;
            Debug.Assert(rootKr != null);

            foreach (NpcDataRootNew item in rootKr.npcs) {
                NpcDataNew dataNew = item.environment;
                if (dataNew == null) continue;

                yield return (item.id, npcNames.GetValueOrDefault(item.id, string.Empty), dataNew, dataNew.effectdummy);
            }
        }
    }
}
