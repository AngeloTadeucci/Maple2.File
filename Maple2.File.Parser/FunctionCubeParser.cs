using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Object;

namespace Maple2.File.Parser;

public class FunctionCubeParser {
    private readonly M2dReader xmlReader;
    public readonly XmlSerializer FunctionCubeSerializer;

    public FunctionCubeParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.FunctionCubeSerializer = new XmlSerializer(typeof(FunctionCubeRoot));
    }

    public IEnumerable<(int Id, FunctionCube Data)> Parse() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("object/"))) {
            var reader = XmlReader.Create(new StringReader(Sanitizer.SanitizeFunctionCube(xmlReader.GetString(entry))));
            var data = FunctionCubeSerializer.Deserialize(reader) as FunctionCubeRoot;
            Debug.Assert(data != null);

            if (data.FunctionCube == null) continue;

            if (int.TryParse(Path.GetFileNameWithoutExtension(entry.Name), out int id)) {
                yield return (id, data.FunctionCube);
            }
        }
    }
}
