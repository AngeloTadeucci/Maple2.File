using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Map;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class MapParser {
    private readonly M2dReader xmlReader;
    public readonly XmlSerializer NameSerializer;
    public readonly XmlSerializer MapSerializer;

    public MapParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        NameSerializer = new XmlSerializer(typeof(StringMapping));
        Type type = FeatureLocaleFilter.Locale == "KR" ? typeof(MapDataRootKR) : typeof(MapDataRoot);
        MapSerializer = new XmlSerializer(type);
    }

    public IEnumerable<(int Id, string Name, MapData Data)> Parse() {
        Dictionary<int, string> mapNames = ParseMapNames();

        IEnumerable<PackFileEntry> entries;
        if (FeatureLocaleFilter.Locale == "KR") {
            entries = [xmlReader.GetEntry("table/fielddata.xml")];
        } else {
            entries = xmlReader.Files.Where(entry => entry.Name.StartsWith("map/"));
        }

        foreach (PackFileEntry entry in entries) {
            XmlReader reader = XmlReader.Create(new StringReader(Sanitizer.SanitizeMap(xmlReader.GetString(entry))));
            if (FeatureLocaleFilter.Locale == "KR") {
                var rootKr = MapSerializer.Deserialize(reader) as MapDataRootKR;
                Debug.Assert(rootKr != null);
                foreach (MapDataRootKR item in rootKr.fieldData) {
                    if (item.environment == null) continue;
                    MapData dataKr = item.environment;
                    yield return (item.id, mapNames.GetValueOrDefault(item.id) ?? string.Empty, dataKr);
                }
                continue;
            }

            var root = MapSerializer.Deserialize(reader) as MapDataRoot;
            Debug.Assert(root != null);

            MapData data = root.environment;
            if (data == null) continue;

            int mapId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (mapId, mapNames.GetValueOrDefault(mapId) ?? string.Empty, data);
        }
    }

    public Dictionary<int, string> ParseMapNames() {
        var reader = xmlReader.GetXmlReader(xmlReader.GetEntry("en/mapname.xml"));
        var mapping = NameSerializer.Deserialize(reader) as StringMapping;
        Debug.Assert(mapping != null);

        return mapping.key.ToDictionary(key => int.Parse(key.id), key => key.name);
    }
}
