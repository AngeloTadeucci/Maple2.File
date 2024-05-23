using System.Numerics;
using Maple2.File.Flat.physxmodellibrary;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2EquipItem : IActor, IPhysXProp {
        string ModelName => "MS2EquipItem";
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
        bool IsReceivingShadow => false;
        string SceneName => "PhysXItemSceneName";
    }
}
