using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.IO.Tok.XmlTypes {
    [XmlRoot("endPoints")]
    public class EndPoints {
        [XmlElement("endPoint")]
        public List<EndPoint> EndPoint;
    }

    [XmlRoot("endPoint")]
    public class EndPoint {
        [XmlAttribute("position")]
        public string Position;
    }
}
