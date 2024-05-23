using System.Xml.Serialization;

namespace Maple2.File.Parser.Enum;

public enum SetCamera {
    None = 0,
    TPSCamera = 1,
    FPSCamera = 2,
    [XmlEnum("2DCamera")]
    _2DCamera = 3,
    RPGCamera = 4,
    PVPCamera = 5,
    ConsoleCamera = 6,
}
