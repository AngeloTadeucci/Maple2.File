using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.triggerslibrary {
    public interface ICollisionSpawnPoint : ISpawnResponse, ICollisionTriggerSource, IMesh {
        string ModelName => "CollisionSpawnPoint";
        uint ActivationCount => 0;
        uint MaxActivations => 1;
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
    }
}
