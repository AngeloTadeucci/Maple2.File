using System.Xml.Serialization;
using Maple2.File.Parser.Xml.Common;

namespace Maple2.File.Parser.Xml.Achieve;

public class Grade {
    [XmlAttribute] public int value;
    [XmlAttribute] public int bigNews;

    [XmlElement] public Condition condition;
    [XmlElement] public Reward reward;
}
