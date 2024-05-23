using System.Xml.Serialization;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Object;

public partial class Camera {
    [XmlAttribute] public SetCamera SetCamera;
}
