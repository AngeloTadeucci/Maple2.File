using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Map;

public class CashCall {
    [XmlAttribute] public bool cashTaxiNotDeparture;
    [XmlAttribute] public bool cashTaxiNotDestination;
    [XmlAttribute] public bool cashCallMedicProhibit;
    [XmlAttribute] public bool cashCallMarketProhibit;
    [XmlAttribute] public bool RecallOtherUserProhibit;
}
