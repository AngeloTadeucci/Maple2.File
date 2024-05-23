using System;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Quest;

public partial class Navigation {
    [M2dEnum] public NavigationType type = NavigationType.unknown;
    [M2dArray] public int[] code = Array.Empty<int>();
    [M2dArray] public int[] map = Array.Empty<int>();
}
