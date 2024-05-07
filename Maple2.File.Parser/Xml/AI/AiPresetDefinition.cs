using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AI;

public class AiPresetDefinition
{
    public string name = string.Empty;

    public List<Entry> entries = new List<Entry>();
}

