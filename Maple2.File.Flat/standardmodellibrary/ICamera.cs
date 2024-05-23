using System.Numerics;

namespace Maple2.File.Flat.standardmodellibrary {
    public interface ICamera : I3DProxy {
        string ModelName => "Camera";
        float FOV => 60;
        float NearPlane => 1;
        float FarPlane => 10000;
        float MinimumNearPlane => 0.1f;
        float MaximumFarToNearRatio => 65536;
        bool IsOrthographic => false;
        int LODAdjust => 1;
        float DOFNear => 250;
        float DOFFar => 18000;
        string ProxyNifAsset => "urn:llid:a27da35d-0000-0000-0000-000000000000";
        float ProxyScale => 0.25f;
        Vector3 Rotation => new Vector3(90, 0, 0);
    }
}
