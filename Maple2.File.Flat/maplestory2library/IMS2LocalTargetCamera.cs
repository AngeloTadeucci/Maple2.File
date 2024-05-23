using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2LocalTargetCamera : ICamera {
        string ModelName => "MS2LocalTargetCamera";
        uint Operate => 0;
        float Scope => 0;
        uint LocalCameraID => 0;
        float TargetDistance => 0;
        Vector3 OffsetPosition => default;
        float InterpolationTime => 0;
        bool ChangeCharacterAngle => false;
        Vector3 CharacterAngle => default;
        bool CharacterMovable => true;
        uint StartInterpolator => 1;
        uint EndInterpolator => 1;
        int BoxID => 0;
        int LocalTargetZoomMin => 0;
        int LocalTargetZoomMax => 0;
        int LocalTargetZoomValue => 0;
        float FOV => 40;
        float ProxyScale => 20;
    }
}
