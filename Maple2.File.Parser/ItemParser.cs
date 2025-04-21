using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Xml.Item;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class ItemParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer nameSerializer;
    private readonly XmlSerializer itemSerializer;

    public ItemParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        nameSerializer = new XmlSerializer(typeof(StringMapping));
        Type type = FeatureLocaleFilter.Locale is "KR" ? typeof(ItemDataKR) : typeof(ItemDataRoot);
        itemSerializer = new XmlSerializer(type);

    }

    public IEnumerable<(int Id, string Name, ItemData Data)> Parse<T>() where T : class {
        Dictionary<int, string> itemNames = ItemNames();
        string folderName = "item/";
        if (FeatureLocaleFilter.Locale == "KR") {
            folderName = "itemdata/";
        }
        foreach (PackFileEntry entry in xmlReader.Files.Where(e => e.Name.StartsWith(folderName))) {
            var xml = itemSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as T;
            switch (xml) {
                case ItemDataRoot root when root.environment != null:
                    int itemId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
                    yield return (itemId, itemNames.GetValueOrDefault(itemId) ?? string.Empty, root.environment);
                    break;
                case ItemDataKR rootKr:
                    foreach (var dataRoot in rootKr.items) {
                        if (dataRoot.environment == null) continue;
                        yield return (dataRoot.id, itemNames.GetValueOrDefault(dataRoot.id) ?? string.Empty, dataRoot.environment);
                    }
                    break;
            }
        }
    }

    public Dictionary<int, string> ItemNames() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("en/itemname.xml"));
        var mapping = nameSerializer.Deserialize(reader) as StringMapping;
        Debug.Assert(mapping != null);

        return mapping.key.ToDictionary(key => int.Parse(key.id), key => key.name);
    }
}
