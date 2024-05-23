using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Object;

public partial class Nurturing {
    [M2dArray] public int[] pluralNpcID = Array.Empty<int>();
    [M2dArray] public int[] rewardItemByFeeding = Array.Empty<int>();
    [M2dArray] public int[] rewardItem = Array.Empty<int>();
    [M2dArray] public int[] requiredGrowth = Array.Empty<int>();
    [M2dArray] public int[] rewardItemByGrowth = Array.Empty<int>();
    [XmlAttribute] public string nurturingQuestTag = string.Empty;
}
