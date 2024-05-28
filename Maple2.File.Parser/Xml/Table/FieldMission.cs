using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/fieldmission.xml
[XmlRoot("ms2")]
public class FieldMissionRoot {
    [XmlElement] public List<FieldMission> round;
}

public partial class FieldMission {
    [XmlAttribute] public int mission;
    [M2dEnum] public QuestRewardType type;
    [M2dArray] public int[] value = Array.Empty<int>();
}
