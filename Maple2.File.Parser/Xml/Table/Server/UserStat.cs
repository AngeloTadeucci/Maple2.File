using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/userStat*.xml
[XmlRoot("ms2")]
public class UserStatRoot {
    [XmlElement] public List<UserStat> stat;
}

public partial class UserStat {
    [XmlAttribute] public short lev;
    [XmlAttribute] public float str;
    [XmlAttribute] public float dex;
    [XmlAttribute] public float @int;
    [XmlAttribute] public float luk;
    [XmlAttribute] public float hp;
    [XmlAttribute] public float hp_rgp;
    [XmlAttribute] public float hp_inv;
    [XmlAttribute] public float sp;
    [XmlAttribute] public float sp_rgp;
    [XmlAttribute] public float sp_inv;
    [XmlAttribute] public float ep;
    [XmlAttribute] public float ep_rgp;
    [XmlAttribute] public float ep_inv;
    [XmlAttribute] public float asp;
    [XmlAttribute] public float msp;
    [XmlAttribute] public float atp;
    [XmlAttribute] public float evp;
    [XmlAttribute] public float cap;
    [XmlAttribute] public float cad;
    [XmlAttribute] public float car;
    [XmlAttribute] public float ndd;
    [XmlAttribute] public float abp;
    [XmlAttribute] public float jmp;
    [XmlAttribute] public float pap;
    [XmlAttribute] public float map;
    [XmlAttribute] public float par;
    [XmlAttribute] public float mar;
    [XmlAttribute] public float wapmin;
    [XmlAttribute] public float wapmax;
    [XmlAttribute] public float dmg;
    [XmlAttribute] public float pen;
    [XmlAttribute] public float base_atk;
    [XmlAttribute] public float sp_value;
}
