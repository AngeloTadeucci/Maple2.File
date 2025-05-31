using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public partial class BasicProperty {
    [XmlAttribute] public short level = 1;
    [XmlAttribute] public int accountEffect; // 0
    [XmlAttribute] public int group;
    [XmlAttribute] public int buffType = 1; // 1,2,3
    [XmlAttribute] public int buffSubType = 0; // 0,1,2,4,6,8,16,32,64,128,256,512,1024
    [XmlAttribute] public int buffCategory; // 0,1,2,4,6,7,8,9,99,1007,2001
    [XmlAttribute] public int eventBuffType; // 0,1,2,3,4
    [XmlAttribute] public bool useInGameTime;
    [XmlAttribute] public int durationTick = 0;
    [XmlAttribute] public int intervalTick = 0;
    [XmlAttribute] public int delayTick;
    [XmlAttribute] public int keepCondition; // 0,1,5,99
    [XmlAttribute] public int resetCondition; // 0,1,2,3
    [XmlAttribute] public int maxBuffCount = 1; // 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,20,30,40,50,60,99,100,140,500
    [XmlAttribute] public int dotCondition; // 0,1,2
    [XmlAttribute] public bool invokeEvent;
    [XmlAttribute] public bool deadKeepEffect;
    [XmlAttribute] public bool logoutClearEffect;
    [XmlAttribute] public bool leaveFieldClearEffect;
    [XmlAttribute] public bool pvpOnOff;
    [XmlAttribute] public bool casterKeepEffect; // 0
    [XmlAttribute] public bool casterIndividualEffect;
    [XmlAttribute] public string coolDownTime = string.Empty;
    [XmlAttribute] public string clearDistanceFromCaster = string.Empty;
    [XmlAttribute] public bool useInvokeEffectFactor; // 0
    [XmlAttribute] public bool clearEffectFromPVPZone;
    [XmlAttribute] public bool doNotClearEffectFromEnterPVPZone;
    [XmlAttribute] public bool clearCooldownFromPVPZone;
    [XmlAttribute] public int forceApplyTarget; // 0,2
    [XmlAttribute] public bool ignoreReduceTimeCondition;
    [XmlAttribute] public int skillSetID; // 0,99910231,99920001,99920002,99920003,99930021,99930041
    [XmlAttribute] public int costumeSetID; // 0,10000001
    [XmlAttribute] public int statSetID; // 0,10000006,10000007,10000008,10000009
    [XmlAttribute] public bool disableRevivalHere;
    [XmlAttribute] public int attackPossibleEffectID; // 0,90000874
    [XmlAttribute] public int skillGroupType = 0; // 0,1,2
    [M2dArray] public int[] attackPossibleSkillIDs = Array.Empty<int>();
    [M2dArray] public int[] attackPossibleDotEffectIDs = Array.Empty<int>();
    [M2dArray] public int[] groupIDs = Array.Empty<int>();
    [XmlAttribute] public bool immediateActiveRequireSkill = false;
    [M2dArray] public int[] itemSlotDisable = Array.Empty<int>();
    [XmlAttribute] public int tailEffect = 0; // 0,1001,1002
    [M2dArray] public int[] upgradeSkillLevelID = Array.Empty<int>();
    [M2dArray] public int[] upgradeSkillLevelValue = Array.Empty<int>();

    // only on new xml
    [XmlAttribute] public int attackPossibleIndividualEffectID;
}
