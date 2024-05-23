using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IEffectMeshWithProxy : IEffectMesh, I3DProxy {
        string ModelName => "EffectMeshWithProxy";
        bool IsVisible => true;
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
    }
}
