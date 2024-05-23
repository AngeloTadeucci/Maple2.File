using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface ISpawnPoint : I3DProxy, IMultiProxy {
        string ModelName => "SpawnPoint";
        float ProxyScale => 1;
        bool IsVisible => true;
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
    }
}
