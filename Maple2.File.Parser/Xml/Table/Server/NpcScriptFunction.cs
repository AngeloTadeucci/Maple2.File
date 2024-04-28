using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/npcScriptFunction_Final.xml
[XmlRoot("ms2")]
public partial class NpcScriptFunctionRoot {
    [M2dFeatureLocale(Selector = "npcID|scriptID")] private IList<NpcScriptFunction> _function;
}

public partial class NpcScriptFunction : IFeatureLocale {
    [XmlAttribute] public int npcID;
    [XmlAttribute] public int scriptID;
    [XmlAttribute] public int functionID;
    [XmlAttribute] public bool endFunction;
    [XmlAttribute] public int portal;
    [XmlAttribute] public string uiName;
    [XmlAttribute] public string uiArg;
    [XmlAttribute] public string uiArg2;
    [XmlAttribute] public int moveFieldID;
    [XmlAttribute] public int moveFieldPortalID;
    [XmlAttribute] public string moveFieldMovie;
    [M2dArray] public int[] presentItemID;
    [M2dArray] public int[] presentItemAmount;
    [M2dArray] public short[] presentItemRank;
    [M2dArray] public int[] collectItemID;
    [M2dArray] public int[] collectItemAmount;
    [XmlAttribute] public int setTriggerValueTriggerID;
    [XmlAttribute] public string setTriggerValueKey;
    [XmlAttribute] public string setTriggerValue;
    [XmlAttribute] public string divorce;
    [XmlAttribute] public long presentExp;
    [XmlAttribute] public long collectMeso;
    [XmlAttribute] public int presentGlobalDropLevel;
    [XmlAttribute] public int presentGlobalDropRank;
    [XmlAttribute] public int presentGlobalDropBoxID;
    [XmlAttribute] public int presentIndivisualDropBoxID;
    [XmlAttribute] public int maidMoodUp;
    [XmlAttribute] public int maidAffinityUp;
    [XmlAttribute] public bool maidPay;
}
