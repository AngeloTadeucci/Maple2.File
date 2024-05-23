using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2TriggerMesh : IMS2TriggerObject, IMS2PhysXProp, I3DProxy {
        string ModelName => "MS2TriggerMesh";
        string hideEffectXml => "";
        string showEffectXml => "";
        string MinimapIconFrame => "";
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
        bool IsVisible => true;
        bool InstancingKeepObject => true;
    }
}
