using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/QuestScriptFunction_Final.xml
[XmlRoot("ms2")]
public partial class QuestScriptFunctionRoot {
    [M2dFeatureLocale(Selector = "questID|scriptID")] private IList<QuestScriptFunction> _function;
}

public partial class QuestScriptFunction : IFeatureLocale {
    [XmlAttribute] public int questID;
    [XmlAttribute] public int scriptID;
    [XmlAttribute] public int functionID;
    [XmlAttribute] public bool endFunction;
    [XmlAttribute] public int portal;
    [XmlAttribute] public string uiName = string.Empty;
    [XmlAttribute] public string uiArg = string.Empty;
    [XmlAttribute] public string uiArg2 = string.Empty;
    [XmlAttribute] public int moveFieldID;
    [XmlAttribute] public int moveFieldPortalID;
    [XmlAttribute] public string moveFieldMovie = string.Empty;
    [XmlAttribute] public string emoticon = string.Empty;
    [M2dArray] public int[] presentItemID = Array.Empty<int>();
    [M2dArray] public int[] presentItemAmount = Array.Empty<int>();
    [M2dArray] public short[] presentItemRank = Array.Empty<short>();
    [M2dArray] public int[] collectItemID = Array.Empty<int>();
    [M2dArray] public int[] collectItemAmount = Array.Empty<int>();
    [XmlAttribute] public int setTriggerValueTriggerID;
    [XmlAttribute] public string setTriggerValueKey = string.Empty;
    [XmlAttribute] public string setTriggerValue = string.Empty;
    [XmlAttribute] public string divorce = string.Empty;
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
