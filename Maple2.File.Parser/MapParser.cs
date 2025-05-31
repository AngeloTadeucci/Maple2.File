using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Map;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class MapParser {
    private readonly M2dReader xmlReader;
    public readonly XmlSerializer NameSerializer;
    public readonly XmlSerializer MapSerializer;
    public readonly XmlSerializer MapNewSerializer;
    private readonly Language language;

    public MapParser(M2dReader xmlReader, Language language) {
        this.xmlReader = xmlReader;
        this.language = language;
        NameSerializer = new XmlSerializer(typeof(StringMapping));
        MapSerializer = new XmlSerializer(typeof(MapDataRoot));
        MapNewSerializer = new XmlSerializer(typeof(MapDataRootKR));
    }

    public IEnumerable<(int Id, string Name, MapData Data)> Parse() {
        Dictionary<int, string> mapNames = ParseMapNames();

        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("map/"))) {
            XmlReader reader = XmlReader.Create(new StringReader(Sanitizer.SanitizeMap(xmlReader.GetString(entry))));

            var root = MapSerializer.Deserialize(reader) as MapDataRoot;
            Debug.Assert(root != null);

            MapData data = root.environment;
            if (data == null) continue;
            int mapId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (mapId, mapNames.GetValueOrDefault(mapId, string.Empty), data);
        }
    }

    public IEnumerable<(int Id, string Name, MapData Data)> ParseNew() {
        Dictionary<int, string> mapNames = ParseMapNames();

        string xml = Sanitizer.RemoveEmpty(xmlReader.GetString(xmlReader.GetEntry("table/fielddata.xml")));
        xml = Sanitizer.SanitizeBool(xml);
        var reader = XmlReader.Create(new StringReader(xml));
        var data = MapNewSerializer.Deserialize(reader) as MapDataRootKR;
        Debug.Assert(data != null);

        foreach (MapDataRootKR item in data.fieldData) {
            if (item.environment == null) continue;
            MapData mapData = item.environment;
            yield return (item.id, mapNames.GetValueOrDefault(item.id, string.Empty), mapData);
        }
    }

    public Dictionary<int, string> ParseMapNames() {
        var reader = xmlReader.GetXmlReader(xmlReader.GetEntry($"{language}/mapname.xml"));
        var mapping = NameSerializer.Deserialize(reader) as StringMapping;
        Debug.Assert(mapping != null);

        return mapping.key.ToDictionary(key => int.Parse(key.id), key => key.name);
    }
}
