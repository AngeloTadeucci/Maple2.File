using System.Diagnostics;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Xml.AdditionalEffect;

namespace Maple2.File.Parser;

public class AdditionalEffectParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer effectSerializer;
    private readonly XmlSerializer effectNewSerializer;

    public AdditionalEffectParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;

        effectSerializer = new XmlSerializer(typeof(AdditionalEffectLevelData));
        effectNewSerializer = new XmlSerializer(typeof(AdditionalEffectDataRootNew));
    }

    public IEnumerable<(int Id, IList<AdditionalEffectData> Data)> Parse() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("additionaleffect/"))) {
            var root = effectSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as AdditionalEffectLevelData;
            Debug.Assert(root != null);

            IList<AdditionalEffectData> data = root.level;
            if (data == null) continue;

            int effectId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (effectId, data);
        }
    }

    public IEnumerable<(int Id, IList<AdditionalEffectDataNew> Data)> ParseNew() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("additional/"))) {
            var root = effectNewSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as AdditionalEffectDataRootNew;

            Debug.Assert(root != null);

            foreach (AdditionalEffectLevelDataNew data in root.additional) {
                //if (data.id != 10200201) continue;
                if (data.level.Count == 0) continue;
                yield return (data.id, data.level);
            }
        }
    }
}
