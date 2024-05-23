using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.triggerslibrary {
    public interface ICollisionTrigger : IMesh, ICollisionTriggerSource, IMultiTargetResponse {
        string ModelName => "CollisionTrigger";
        string NifAsset => "urn:TriggerProxy";
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
        uint ActivationCount => 0;
        uint MaxActivations => 1;
    }
}
