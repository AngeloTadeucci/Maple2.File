using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Script;

// ./data/xml/script/npc/%08d.xml
[XmlRoot("ms2")]
public partial class NpcScript {
    [M2dFeatureLocale(Selector = "id")] private IList<TalkScript> _select;
    [M2dFeatureLocale] private TalkScript _job;
    [M2dFeatureLocale(Selector = "id")] private IList<MonologueScript> _monologue;
    [M2dFeatureLocale(Selector = "id")] private IList<ConditionTalkScript> _script;
}

[XmlRoot("ms2")]
public partial class NpcScriptListKr {
    [XmlElement("npc")] public List<NpcScriptKR> npcs;
}

public partial class NpcScriptKR : NpcScript {
    [XmlAttribute("id")] public int id;
}
