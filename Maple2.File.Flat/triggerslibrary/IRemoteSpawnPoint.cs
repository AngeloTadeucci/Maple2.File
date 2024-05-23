using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.triggerslibrary {
    public interface IRemoteSpawnPoint : ISpawnResponse, IMesh {
        string ModelName => "RemoteSpawnPoint";
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
    }
}
