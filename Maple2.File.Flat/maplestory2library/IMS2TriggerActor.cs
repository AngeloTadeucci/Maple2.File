using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2TriggerActor : IMS2TriggerObject, IMS2Actor, I3DProxy {
        string ModelName => "MS2TriggerActor";
        string MinimapIconFrame => "";
        bool IsVisible => true;
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
    }
}
