using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/OxQuiz.xml
[XmlRoot("ms2")]
public class OxQuizRoot {
    [XmlElement] public List<OxQuiz> OxQuiz;
}

public class OxQuiz {
    [XmlAttribute] public int quizID;
    [XmlAttribute] public int categoryID;
    [XmlAttribute] public string categoryStr = string.Empty;
    [XmlAttribute] public string quizStr = string.Empty;
    [XmlAttribute] public int level;
    [XmlAttribute] public bool answer;
    [XmlAttribute] public string answerStr = string.Empty;
}
