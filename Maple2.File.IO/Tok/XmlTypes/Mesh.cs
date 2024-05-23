using System.Xml.Serialization;

namespace Maple2.File.IO.Tok.XmlTypes {
    [XmlRoot("mesh")]
    public class Mesh {
        [XmlAttribute("majorRelease")]
        public sbyte MajorRelease;
        [XmlAttribute("minorRelease")]
        public sbyte MinorRelease;
        [XmlAttribute("maxStepHeight")]
        public short MaxStepHeight;
        [XmlElement("mesh3D")]
        public Mesh3D Mesh3D;
        [XmlElement("mappingTo2D")]
        public MappingTo2D MappingTo2D;
        [XmlElement("offMeshConnections")]
        public OffMeshConnections OffMeshConnections;
    }
}
