using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Skill;

public partial class Basic : IFeatureLocale {
    [XmlElement] public UI ui;
    [XmlElement] public Kinds kinds;
    [XmlElement] public StateAttribute stateAttr;
}
