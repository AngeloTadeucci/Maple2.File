using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Xml.Item;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class ItemParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer nameSerializer;
    private readonly XmlSerializer itemSerializer;
    private readonly XmlSerializer itemNewSerializer;
    private readonly string language;

    public ItemParser(M2dReader xmlReader, string language) {
        this.xmlReader = xmlReader;
        this.language = language.ToLower();
        nameSerializer = new XmlSerializer(typeof(StringMapping));
        itemSerializer = new XmlSerializer(typeof(ItemDataRoot));
        itemNewSerializer = new XmlSerializer(typeof(ItemDataNew));
    }

    public IEnumerable<(int Id, string Name, ItemData Data)> Parse() {
        Dictionary<int, string> itemNames = ItemNames();
        foreach (PackFileEntry entry in xmlReader.Files.Where(e => e.Name.StartsWith("item/"))) {
            var xml = itemSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as ItemDataRoot;
            Debug.Assert(xml != null);

            if (xml.environment == null) continue;
            int itemId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (itemId, itemNames.GetValueOrDefault(itemId, string.Empty), xml.environment);
        }
    }

    public IEnumerable<(int Id, string Name, ItemData Data)> ParseNew() {
        Dictionary<int, string> itemNames = ItemNames();
        foreach (PackFileEntry entry in xmlReader.Files.Where(e => e.Name.StartsWith("itemdata/"))) {
            var xml = itemNewSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as ItemDataNew;
            Debug.Assert(xml != null);

            foreach (ItemDataRootNew dataRoot in xml.item) {
                if (dataRoot.environment == null) continue;
                yield return (dataRoot.id, itemNames.GetValueOrDefault(dataRoot.id, string.Empty), dataRoot.environment);
            }
        }
    }

    public Dictionary<int, string> ItemNames() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry($"{language}/itemname.xml"));
        var mapping = nameSerializer.Deserialize(reader) as StringMapping;
        Debug.Assert(mapping != null);

        return mapping.key.ToDictionary(key => int.Parse(key.id), key => key.name);
    }
}
