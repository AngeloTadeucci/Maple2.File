using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/fieldmetadata.xml
//
// Only the <fieldPortal> section is modelled. The file also carries <npc>, <interactObject>,
// <fluid>, <liftable>, <pet> and <taxiStation> sections, which nothing consumes yet.
[XmlRoot("ms2")]
public partial class FieldMetaDataRoot {
    [M2dFeatureLocale(Selector = "field")] private IList<FieldPortal> _fieldPortal;
}

// The client builds its sub-map to exploration-zone table from these entries: portals with
// portalIndoor != 0 are edges, and every map reachable from an indoor="0" entry belongs to
// that outdoor field. See PrivateMaple2 docs/client-re/field-mission-binding.md.
public partial class FieldPortal : IFeatureLocale {
    [XmlAttribute] public int field;
    [XmlAttribute] public bool indoor;
    [XmlElement] public List<Portal> portal = new();

    // <portal id="17" targetField="2000025" targetPortal="1" portalType="0" portalIndoor="1" />
    public partial class Portal {
        [XmlAttribute] public int id;
        [XmlAttribute] public int targetField;
        [XmlAttribute] public int targetPortal;
        [XmlAttribute] public int portalType;
        [XmlAttribute] public bool portalIndoor;
    }
}
