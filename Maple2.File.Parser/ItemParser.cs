﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml;
using Maple2.File.Parser.Xml.Item;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class ItemParser {
    private readonly M2dReader xmlReader;
    private readonly Filter filter;
    private readonly XmlSerializer nameSerializer;
    private readonly XmlSerializer itemSerializer;

    public ItemParser(M2dReader xmlReader, Filter filter) {
        this.xmlReader = xmlReader;
        this.filter = filter;
        this.nameSerializer = new XmlSerializer(typeof(StringMapping));
        this.itemSerializer = new XmlSerializer(typeof(ItemDataRoot));
    }

    public IEnumerable<(int Id, string Name, ItemData Data)> Parse() {
        XmlReader reader = xmlReader.GetXmlReader("en/itemname.xml");
        var mapping = nameSerializer.Deserialize(reader) as StringMapping;
        Debug.Assert(mapping != null);

        Dictionary<int, string> itemNames = mapping.Filter(filter);

        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("item/"))) {
            var root = itemSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as ItemDataRoot;
            Debug.Assert(root != null);

            ItemData data = root.Filter(filter);
            if (data == null) continue;

            int itemId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (itemId, itemNames.GetValueOrDefault(itemId), data);
        }
    }
}
