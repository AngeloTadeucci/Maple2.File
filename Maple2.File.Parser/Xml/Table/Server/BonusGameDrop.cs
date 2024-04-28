using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/BonusGameDrop.xml
[XmlRoot("ms2")]
public partial class BonusGameDropRoot {
    [M2dFeatureLocale(Selector = "gameType|gameID")] private IList<BonusGameDrop> _game;
}

public partial class BonusGameDrop : IFeatureLocale {
    [XmlAttribute] public int gameType;
    [XmlAttribute] public int gameID;
    [XmlElement] public List<Item> item;

    public class Item {
        [XmlAttribute] public int id;
        [XmlAttribute] public short rank;
        [XmlAttribute] public int count;
        [XmlAttribute] public int prop;
        [XmlAttribute] public bool notice;
    }
}
