using System;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.AI;

public class RideNode : NodeEntry {
    public NodeRideType type;
    public bool isRideOff;
    public int[] rideNpcIDs = Array.Empty<int>();
}
