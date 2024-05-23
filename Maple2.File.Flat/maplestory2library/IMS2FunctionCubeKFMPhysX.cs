using System.Numerics;
using Maple2.File.Flat.physxmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2FunctionCubeKFMPhysX : IMS2FunctionCubeKFM, IPhysXProp {
        string ModelName => "MS2FunctionCubeKFMPhysX";
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
    }
}
