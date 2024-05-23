using System;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Object;

public partial class FittingDoll {
    [M2dEnum] public Gender fittingdollGender;
    [XmlAttribute] public int fittingdollType;
    [M2dArray] public int[] fittingdollDefaultItem = Array.Empty<int>();
    [M2dArray] public int[] fittingdollSkinColor0 = Array.Empty<int>();
    [M2dArray] public int[] fittingdollSkinColor1 = Array.Empty<int>(); // Unused? string?
    [M2dArray] public int[] fittingdollSkinColor2 = Array.Empty<int>();
}
