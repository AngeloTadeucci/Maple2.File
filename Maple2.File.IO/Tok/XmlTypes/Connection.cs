using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.IO.Tok.XmlTypes {
    [XmlRoot("connections")]
    public class Connections {
        [XmlElement("connection")]
        public List<Connection> Connection;
    }

    [XmlRoot("connection")]
    public class Connection {
        [XmlAttribute("from")]
        public short From;
        [XmlAttribute("to")]
        public short To;
        [XmlAttribute("penalty")]
        public sbyte Penalty;
    }
}
