using System;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public partial class ModifyEffectDurationProperty {
    [M2dArray] public int[] effectCodes = Array.Empty<int>();
    [M2dArray] public float[] durationFactors = Array.Empty<float>();
    [M2dArray] public float[] durationValues = Array.Empty<float>();
}
