using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.IO.Tok.XmlTypes {
    [XmlRoot("mappingTo2D")]
    public class MappingTo2D {
        [XmlElement("poly")]
        public List<Polygon> Polygons;
    }
}
