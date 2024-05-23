using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2GameplayCamera : ICamera {
        string ModelName => "MS2GameplayCamera";
        float FOV => 65;
        float NearPlane => 10;
        float FarPlane => 100000;
        float MaximumFarToNearRatio => 10000;
    }
}
