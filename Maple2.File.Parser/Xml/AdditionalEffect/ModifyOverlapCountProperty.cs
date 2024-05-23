using System;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public partial class ModifyOverlapCountProperty {
    [M2dArray] public int[] effectCodes = Array.Empty<int>();
    [M2dArray] public int[] offsetCounts = Array.Empty<int>();
}
