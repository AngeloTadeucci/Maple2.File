using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/chapterbook.xml
[XmlRoot("ms2")]
public partial class ChapterBookRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<ChapterBook> _chapterbook;
}

public partial class ChapterBook : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int prologue;
    [XmlAttribute] public int epilogue;
    [XmlAttribute] public QuestRewardType rewardType1;
    [M2dArray] public string[] rewardValue1 = Array.Empty<string>();
    [XmlAttribute] public QuestRewardType rewardType2;
    [M2dArray] public string[] rewardValue2 = Array.Empty<string>();
}
