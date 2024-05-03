using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/room_random.xml
[XmlRoot("ms2")]
public class RoomRandomRoot {
    [XmlElement] public List<RandomRoom> randomroom;
    [XmlElement] public List<RoomRandom> room;
}

public class RandomRoom {
    [XmlAttribute] public int id;
    [XmlAttribute] public int prob;
    [XmlElement] public List<Ref> @ref;

    public class Ref {
        [XmlAttribute] public int roomid;
        [XmlAttribute] public int weight;
    }
}

public partial class RoomRandom {
    [XmlAttribute] public int id;
    [M2dArray] public int[] fieldIDs = Array.Empty<int>();
    [XmlAttribute] public int roomdurationTick;
    [XmlAttribute] public string nifAssetName = string.Empty;
    [XmlAttribute] public int maxUserCount;
    [XmlAttribute] public int autoClosing;
}
