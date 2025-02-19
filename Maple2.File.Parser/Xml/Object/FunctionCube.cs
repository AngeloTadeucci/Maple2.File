using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Object;

// ./data/xml/object/%08d.xml
[XmlRoot("ms2")]
public class FunctionCubeRoot {
    [XmlElement] public FunctionCube FunctionCube;
    [XmlElement] public ConfigurableCube? ConfigurableCube;
}

public partial class FunctionCube {
    [XmlAttribute] public bool UseKfm;
    [XmlAttribute] public int DefaultState;
    [XmlAttribute] public string ControlType = string.Empty;
    [M2dEnum] public StateChangeAction StateChangeAction;
    [XmlAttribute] public int StateChangeActionPermissionType;
    [M2dEnum] public UseUiFunction UseUiFunction;
    [XmlAttribute] public string ZeroSeq = string.Empty;
    [XmlAttribute] public string FirstSeq = string.Empty;
    [XmlAttribute] public string SecondSeq = string.Empty;
    [XmlAttribute] public string ZeroIngSeq = string.Empty;
    [XmlAttribute] public string FirstIngSeq = string.Empty;
    [XmlAttribute] public string SecondIngSeq = string.Empty;
    [XmlAttribute] public string ZeroEffect = string.Empty;
    [XmlAttribute] public string FirstEffect = string.Empty;
    [XmlAttribute] public string SecondEffect = string.Empty;
    [XmlAttribute] public string ZeroIngEffect = string.Empty;
    [XmlAttribute] public string FirstIngEffect = string.Empty;
    [XmlAttribute] public string SecondIngEffect = string.Empty;
    [XmlAttribute] public float ZeroPhysics = 150f;
    [XmlAttribute] public int FirstPhysics = 1;
    [XmlAttribute] public int SecondPhysics;
    [M2dArray(Delimiter = '-')] public int[] AutoStateChange = Array.Empty<int>();
    [XmlAttribute] public int AutoStateChangeTime;
    [XmlAttribute] public bool enableTriggerControl;
    [XmlAttribute] public int receipeID;
    [XmlAttribute] public string reactableEffect = string.Empty;

    [XmlElement] public Camera camera;
    [XmlElement] public Spawner spawner;
    [XmlElement] public Fusioner fusioner;
    [XmlElement] public FittingDoll fittingdoll;
    [XmlElement] public SkillObject skillobject;
    [XmlElement] public FirstPcAnimation firstPCAnimation;
    [XmlElement] public FirstAdditionalEffect firstAdditionalEffect;
    [XmlElement] public Forbidden forbidden;
    [XmlElement] public Pvp pvp;
    [XmlElement] public OpenWeb openWeb;
    [XmlElement] public NoticePopup noticePopup;
    [XmlElement] public Nurturing nurturing;
}

public partial class ConfigurableCube {
    [XmlAttribute] public bool enabled;
    [M2dEnum] public ConfigurableCubeType id;
}
