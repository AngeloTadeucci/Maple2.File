using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/fishLure.xml
[XmlRoot("ms2")]
public partial class FishLureRoot {
    [M2dFeatureLocale(Selector = "additionalEffectCode")] private IList<FishLure> _lure;
}

public partial class FishLure : IFeatureLocale {
    [XmlAttribute] public int additionalEffectCode;
    [XmlAttribute] public int additionalEffectLevel;
    [XmlAttribute] public int fishCode;
    [M2dArray] public int[] catchRank = Array.Empty<int>();
    [M2dArray] public int[] catchProp = Array.Empty<int>();
    [M2dArray] public int[] spawnRank = Array.Empty<int>();
    [M2dArray] public int[] spawnProp = Array.Empty<int>();
    [M2dArray] public int[] spawnFish = Array.Empty<int>();
    [M2dArray] public int[] spawnFishRate = Array.Empty<int>();
    [XmlAttribute] public int fishSize;
    [XmlAttribute] public int fishSizeProp;
    [XmlAttribute] public int globalDropBoxID;
    [XmlAttribute] public int globalDropRank;
    [M2dArray(Delimiter = '-')] public int[] globalDropFishingSpotMastery = Array.Empty<int>();
    [XmlAttribute] public int individualDropBoxID;
    [XmlAttribute] public int individualDropRank;
    [M2dArray(Delimiter = '-')] public int[] individualDropFishingSpotMastery = Array.Empty<int>();
}
