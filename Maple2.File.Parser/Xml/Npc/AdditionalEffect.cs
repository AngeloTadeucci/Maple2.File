﻿using System;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc;

public partial class AdditionalEffect {
    [M2dArray] public int[] codes = Array.Empty<int>();
    [M2dArray] public short[] levels = Array.Empty<short>();
    [M2dArray(Delimiter = ':')] public string[] group = Array.Empty<string>();
    [M2dArray] public int[] rewardCodes = Array.Empty<int>();
    [M2dArray] public short[] rewardLevels = Array.Empty<short>();
}
