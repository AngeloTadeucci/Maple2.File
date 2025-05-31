using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public partial class ModifySkillCooldown {
    [M2dArray] public int[] skillIDs = Array.Empty<int>();
    [M2dArray] public float[] values = Array.Empty<float>();
}
