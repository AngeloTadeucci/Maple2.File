using Maple2.File.Parser.Xml.AI;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using System.Text.RegularExpressions;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Table;
using System.Xml;

namespace Maple2.File.Parser;

public class AiParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer aiSerializer;

    public AiParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.aiSerializer = new XmlSerializer(typeof(NpcAi));
    }

    public IEnumerable<(string aiName, NpcAi Data)> Parse() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("AI/"))) {
            string sanitized = Sanitizer.SanitizeAi(xmlReader.GetString(entry));
            var root = aiSerializer.Deserialize(XmlReader.Create(new StringReader(sanitized))) as NpcAi;

            Debug.Assert(root != null);

            // removing the AI/ prefix because the <aiInfo path> attribute is relative to AI
            string aiName = entry.Name.Substring(3);

            yield return (aiName, root);
        }
    }
}
