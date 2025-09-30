using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class BanWordParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer nameSerializer;

    public BanWordParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        nameSerializer = new XmlSerializer(typeof(StringMapping));
    }

    public IEnumerable<(int Id, string Name)> ParseBanWords() {
        int i = 0;
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.Contains("banword") && !entry.Name.Contains("ugc"))) {
            XmlReader reader = xmlReader.GetXmlReader(entry);
            var mapping = nameSerializer.Deserialize(reader) as StringMapping;

            Debug.Assert(mapping != null);

            Dictionary<int, string> banWords = mapping.key.ToDictionary(_ => i++, key => key.name);
            foreach (var banWord in banWords) {
                if (string.IsNullOrEmpty(banWord.Value)) {
                    continue;
                }
                yield return (banWord.Key, banWord.Value);
            }
        }
    }

    public IEnumerable<(int Id, string Name)> ParseUgcBanWords() {
        int i = 0;
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.Contains("ugcbanword"))) {
            XmlReader reader = xmlReader.GetXmlReader(entry);
            var mapping = nameSerializer.Deserialize(reader) as StringMapping;

            Debug.Assert(mapping != null);

            Dictionary<int, string> banWords = mapping.key.ToDictionary(_ => i++, key => key.name);
            foreach (var banWord in banWords) {
                if (string.IsNullOrEmpty(banWord.Value)) {
                    continue;
                }
                yield return (banWord.Key, banWord.Value);
            }
        }
    }
}
