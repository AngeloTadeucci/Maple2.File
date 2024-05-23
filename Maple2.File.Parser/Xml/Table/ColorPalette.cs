using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/colorpalette.xml
// ./data/xml/table/na/colorpalette_achieve.xml
[XmlRoot("ms2")]
public class ColorPaletteRoot {
    [XmlElement] public List<ColorPalette> colorPalette;
}

public partial class ColorPalette {
    [XmlAttribute] public int id;

    [XmlElement] public List<Color> color;

    public partial class Color {
        [M2dColor] public System.Drawing.Color ch0;
        [M2dColor] public System.Drawing.Color ch1;
        [M2dColor] public System.Drawing.Color ch2;
        [M2dColor] public System.Drawing.Color palette;
        [XmlAttribute] public bool show2color;
        [XmlAttribute] public int achieveID;
        [XmlAttribute] public int achieveGrade;
        [XmlAttribute] public int stringKey;
        [XmlAttribute] public int colorSN;
        [M2dColor] public System.Drawing.Color ch0_eye;
        [M2dColor] public System.Drawing.Color ch2_eye;
    }
}
