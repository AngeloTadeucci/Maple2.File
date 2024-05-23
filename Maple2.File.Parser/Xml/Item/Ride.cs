using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Item;

public class Ride {
    [XmlAttribute] public float rideBuildScale;
    [XmlAttribute] public int rideMonster;
}
