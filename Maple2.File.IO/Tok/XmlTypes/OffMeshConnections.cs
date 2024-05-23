using System.Xml.Serialization;

namespace Maple2.File.IO.Tok.XmlTypes {
    [XmlRoot("offMeshConnections")]
    public class OffMeshConnections {
        [XmlElement("endPoints")]
        public EndPoints EndPoints;
        [XmlElement("connections")]
        public Connections Connections;
    }
}
