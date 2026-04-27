using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/magicPath.xml
[XmlRoot("ms2")]
public class MagicPath {
    [XmlElement] public List<MagicType> type;
}

public class MagicType {
    [XmlAttribute] public long id;

    [XmlElement] public List<MagicData> move;
}

public partial class MagicData {
    [M2dVector3] public Vector3 fireOffsetPosition;
    [M2dVector3] public Vector3 fireFixedPosition;
    [XmlAttribute] public string fireNode = string.Empty;
    [M2dVector3] public Vector3 direction = Vector3.UnitY;
    [XmlAttribute] public float dirRotZDegree;
    [M2dVector3] public Vector3 controlValue0;
    [M2dVector3] public Vector3 controlValue1;
    [M2dVector3] public Vector3 controlEndOffsetValue;
    [XmlAttribute] public float lifeTime;
    [XmlAttribute] public float delayTime;
    [XmlAttribute] public float spawnTime;
    [XmlAttribute] public bool ignoreCancelAtSpawnTime;
    [XmlAttribute] public float vel;
    [XmlAttribute] public float distance;
    [XmlAttribute] public float nonTargetMoveDistance;
    [XmlAttribute] public float destroyTime;
    [XmlAttribute] public float controlRate;
    [XmlAttribute] public int lookAtType;
    [XmlAttribute] public int catmullrom;
    [XmlAttribute] public bool rotation = true;
    [XmlAttribute] public float traceTargetDuration;
    [XmlAttribute] public bool explosionByDestroy = true;
    [XmlAttribute] public bool traceTargetOffsetPos;
    [XmlAttribute] public bool ignorePhysxTestInitPosition;
    [XmlAttribute] public int piercingAttackInterval;
    [XmlAttribute] public int piercingAttackMaxTargetCount;

    [XmlAttribute] public int moveEndHoldDuration;
    //public float timeInterval => vel / distance;

    // Ignored by client.
    [XmlAttribute] public bool align = true;
    [XmlAttribute] public int alignCubeHeight;
    [XmlAttribute] public bool ignoreAdjustCubePosition = false;
}
