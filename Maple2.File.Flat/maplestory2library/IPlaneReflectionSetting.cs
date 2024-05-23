using System.Numerics;

namespace Maple2.File.Flat.maplestory2library {
    public interface IPlaneReflectionSetting : IMapEntity {
        string ModelName => "PlaneReflectionSetting";
        bool Enabled => false;
        Vector3 Point => default;
        Vector3 Normal => new Vector3(0, 0, 1);
    }
}
