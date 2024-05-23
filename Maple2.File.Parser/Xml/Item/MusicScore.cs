using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Item;

public class MusicScore {
    [XmlAttribute] public int playCount;
    [XmlAttribute] public int masteryValue;
    [XmlAttribute] public int masteryValueMax;
    [XmlAttribute] public bool isCustomNote;
    [XmlAttribute] public int noteLengthMax;
    [XmlAttribute] public string fileName = string.Empty;
    [XmlAttribute] public int playTime;
    [XmlAttribute] public int recommendCategoryId;
}
