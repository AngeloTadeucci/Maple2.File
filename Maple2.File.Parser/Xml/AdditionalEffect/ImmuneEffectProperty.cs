using System;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public partial class ImmuneEffectProperty {
    [M2dArray] public int[] immuneEffectCodes = Array.Empty<int>();
    [M2dArray] public int[] immuneBuffCategories = Array.Empty<int>();
}
