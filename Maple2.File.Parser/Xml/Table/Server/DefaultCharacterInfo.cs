using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/defaultCharacterInfo.xml
[XmlRoot("ms2")]
public class DefaultCharacterInfoRoot {
    [XmlElement] public List<DefaultCharacterInfo> gender = [];
}

public partial class DefaultCharacterInfo {
    [M2dEnum] public Gender value = Gender.Invalid;
    [XmlElement] public Skin skin = new();
    [XmlElement] public Items items = new();

    public class Skin {
        [XmlAttribute] public int colorPaletteID;
        // Absent where the entry keeps the palette's own default swatch.
        [XmlAttribute] public int colorSN = -1;
    }

    public class Items {
        [XmlElement] public List<Item> item = [];
    }

    public class Item {
        [XmlAttribute] public int id;
        // Equip slot code: HR, FA, FD, ER.
        [XmlAttribute] public string slotHint = string.Empty;
        [XmlAttribute] public int colorPaletteID;
        [XmlAttribute] public int colorSN = -1;
        [XmlElement] public Controls controls = new();
    }

    public class Controls {
        [XmlElement] public List<Control> control = [];
    }

    public partial class Control {
        [XmlAttribute] public int index;
        [XmlAttribute] public float scale;
        [M2dVector3] public Vector3 position;
        [M2dVector3] public Vector3 rotation;
    }
}
