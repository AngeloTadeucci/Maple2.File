using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/BonusGame.xml
[XmlRoot("ms2")]
public partial class BonusGameRoot {
    [M2dFeatureLocale(Selector = "gameType|gameID")] private IList<BonusGame> _game;
}

public partial class BonusGame : IFeatureLocale {
    [XmlAttribute] public int gameType;
    [XmlAttribute] public int gameID;
    [XmlAttribute] public int consumeItemID;
    [XmlAttribute] public int consumeItemCount;
    [XmlElement] public List<Slot> slot;

    public class Slot {
        [XmlAttribute] public int minProp;
        [XmlAttribute] public int maxProp;
    }
}
