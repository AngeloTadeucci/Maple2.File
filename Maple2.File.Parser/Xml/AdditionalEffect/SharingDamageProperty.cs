﻿using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect {
    public class SharingDamageProperty {
        [XmlAttribute] public float sharingDamageRate;
        [XmlAttribute] public float sharingDamageReduceRate;
    }
}