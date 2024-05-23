using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml;

// ./data/xml/ugcmap/%08d.xml
[XmlRoot("ugcmap")]
public partial class UgcMap {
    [XmlAttribute] public string name = string.Empty;
    [XmlAttribute] public int sandbox;

    [XmlElement] public List<Group> group;
    [XmlElement] public List<Floor> floor;

    public partial class Group {
        [XmlAttribute] public int no;
        [XmlAttribute] public int contractPrice = int.MaxValue;
        [XmlAttribute] public int contractPriceItemCode;
        [XmlAttribute] public int ugcHomeContractDate;
        [XmlAttribute] public int ugcHomeExtensionDate;
        [XmlAttribute] public int heightLimit;
        [XmlAttribute] public int installableBuildingCount;
        [XmlAttribute] public int returnPlaceID;
        [XmlAttribute] public int sellType;
        [XmlAttribute] public int builingType;
        [XmlAttribute] public int area;
        [XmlAttribute] public int indoorCount;
        [XmlAttribute] public int extensionPrice = int.MaxValue;
        [XmlAttribute] public int extensionPriceItemCode;
        [XmlAttribute] public int houseNumber;
        [XmlAttribute] public string previewIcon = string.Empty;
        [XmlAttribute] public int blockCode;
        [M2dArray] public int[] privilegeNPC = Array.Empty<int>();
        [M2dArray] public int[] privilegePortal = Array.Empty<int>();
        [M2dArray] public int[] privilegeInteract = Array.Empty<int>();
        [XmlAttribute] public int maidCount;
        [XmlAttribute] public int triggerCount;
        [XmlAttribute] public int installNpcCount;
        [XmlAttribute] public bool privilegeTaxi;
        [XmlAttribute] public bool hideEmoticon;
        [XmlAttribute] public int trophyID;
        [XmlAttribute] public bool adminOnly;
        [XmlAttribute] public string indoorSizeType = string.Empty;
        [XmlAttribute] public bool useCouponEvent;

        // Ignored by client.
        [XmlAttribute] public int widthUIDescription;
        [XmlAttribute] public int lengthUIDescription;
    }

    public class Floor {
        [XmlAttribute] public int id;
        [XmlAttribute] public float start_height;
        [XmlAttribute] public int step;
    }
}

// ./data/xml/exportedugcmap/%08d.xml
[XmlRoot("ugcmap")]
public partial class ExportedUgcMap {
    [M2dArray] public int[] baseCubePoint3 = { 0, 0, 0 };
    [M2dArray(Delimiter = 'x')] public int[] indoorSizeType = { 0, 0, 0 };

    [XmlElement] public List<Cube> cube;

    public partial class Cube {
        [XmlAttribute] public int itemID;
        [M2dArray] public int[] offsetCubePoint3 = { 0, 0, 0 };
        [XmlAttribute] public int rotation;
        [XmlAttribute] public int wallDir;
    }
}
