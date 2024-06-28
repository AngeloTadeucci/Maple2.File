using System.Xml.Serialization;
using M2dXmlGenerator;
using DayOfWeek = Maple2.File.Parser.Enum.DayOfWeek;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/NA/GameEvent.xml
[XmlRoot("ms2")]
public partial class GameEventRoot {
    [M2dFeatureLocale(Selector = "gameEventID")] private IList<GameEvent> _gameEvent;
}

public partial class GameEvent : IFeatureLocale {
    [XmlAttribute] public int gameEventID;
    [XmlAttribute] public string eventType = string.Empty;
    [XmlAttribute] public string eventStart = string.Empty;
    [XmlAttribute] public string eventEnd = string.Empty;
    [XmlAttribute] public string partTime = string.Empty;
    [M2dArray] public DayOfWeek[] dayOfWeek = Array.Empty<DayOfWeek>();
    [XmlAttribute] public string value1 = string.Empty;
    [XmlAttribute] public string value2 = string.Empty;
    [XmlAttribute] public string value3 = string.Empty;
    [XmlAttribute] public string value4 = string.Empty;
    [XmlAttribute] public string reference = string.Empty;
}
