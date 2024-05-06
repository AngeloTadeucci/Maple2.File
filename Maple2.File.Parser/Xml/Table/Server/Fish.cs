using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/fish.xml
[XmlRoot("ms2")]
public partial class FishRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<Fish> _fish;
}

public partial class Fish : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public bool fishingBook;
    [XmlAttribute] public string habitat = string.Empty;
    [XmlAttribute] public int fishMastery;
    [XmlAttribute] public short rank;
    [XmlAttribute] public string smallSize = string.Empty;
    [XmlAttribute] public string bigSize = string.Empty;
    [XmlAttribute] public bool ignoreSpotMastery;
    [XmlAttribute] public int lv;
    [XmlAttribute] public int pointCount;
    [XmlAttribute] public int masteryPoint;
    [XmlAttribute] public int exp;
    [XmlAttribute] public int fishingTime;
    [XmlAttribute] public int catchProp;
    [XmlAttribute] public int baitProp;
    [XmlAttribute] public int companion;
    [M2dArray] public int[] bait = Array.Empty<int>();
    [XmlAttribute] public int individualDropBoxID;
}
