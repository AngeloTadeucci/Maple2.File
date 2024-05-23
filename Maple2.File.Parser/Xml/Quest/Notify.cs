using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Quest;

public partial class Notify {
    [M2dEnum] public UiEffect completeUiEffect = UiEffect.unknown;
    [XmlAttribute] public string acceptSoundKey = string.Empty;
    [XmlAttribute] public string completeSoundKey = string.Empty;
}
