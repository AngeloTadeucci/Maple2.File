using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/InstanceField.xml
[XmlRoot("ms2")]
public class InstanceFieldRoot {
    [XmlElement] public List<InstanceField> InstanceField;
}

public partial class InstanceField {
    [XmlAttribute] public int instanceID;
    [M2dEnum] public InstanceType instanceType;
    [M2dArray] public int[] fieldIDs;
    [XmlAttribute] public bool backupSourcePortal;
    [XmlAttribute] public int poolCount;
    [XmlAttribute] public bool isSaveField;
    [XmlAttribute] public int npcStatFactorID;
    [XmlAttribute] public int maxCount;
    [XmlAttribute] public byte openType;
    [XmlAttribute] public int openValue;
}
