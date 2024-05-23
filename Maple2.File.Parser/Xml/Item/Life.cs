using System;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Item;

public partial class Life {
    [XmlAttribute] public int usePeriod;
    [M2dArray(Delimiter = '-')] public int[] expirationPeriod = Array.Empty<int>();
    [XmlAttribute] public int expirationType;
    [XmlAttribute] public int numberOfWeeksMonths;
}
