using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Npc;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class NpcParser {
    private readonly M2dReader xmlReader;
    public readonly XmlSerializer NameSerializer;
    public readonly XmlSerializer NpcSerializer;

    public NpcParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        NameSerializer = new XmlSerializer(typeof(StringMapping));
        Type type = FeatureLocaleFilter.Locale == "KR" ? typeof(NpcDataListKR) : typeof(NpcDataRoot);
        NpcSerializer = new XmlSerializer(type);
    }

    public Dictionary<int, string> ParseNpcNames() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("en/npcname.xml"));
        var npcNames = NameSerializer.Deserialize(reader) as StringMapping;
        Debug.Assert(npcNames != null);
        return npcNames.key.ToDictionary(key => int.Parse(key.id), key => key.name);
    }

    public IEnumerable<(int Id, string Name, NpcData Data, List<EffectDummy> Dummy)> Parse() {
        var npcNames = ParseNpcNames();
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("npc/"))) {
            var reader = XmlReader.Create(new StringReader(Sanitizer.SanitizeNpc(xmlReader.GetString(entry))));
            var root = NpcSerializer.Deserialize(reader) as NpcDataRoot;
            Debug.Assert(root != null);

            NpcData data = root.environment;
            if (data == null) continue;

            int npcId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (npcId, npcNames.GetValueOrDefault(npcId) ?? string.Empty, data, root.effectdummy);
        }
    }

    public IEnumerable<(int Id, string Name, NpcDataKR Data, List<EffectDummy> Dummy)> ParseKR() {
        var npcNames = ParseNpcNames();
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("npcdata/"))) {
            var reader = XmlReader.Create(new StringReader(Sanitizer.SanitizeNpc(xmlReader.GetString(entry))));
            var rootKr = NpcSerializer.Deserialize(reader) as NpcDataListKR;
            Debug.Assert(rootKr != null);

            foreach (NpcDataRootKR item in rootKr.npcs) {
                NpcDataKR dataKr = item.environment;
                if (dataKr == null) continue;

                yield return (item.id, npcNames.GetValueOrDefault(item.id) ?? string.Empty, dataKr, dataKr.effectdummy);
            }
        }
    }
}
