using System.Numerics;

namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPointLight : ILight, IShadowGenerator {
        string ModelName => "PointLight";
        float ConstantAttenuation => 1;
        float LinearAttenuation => 0;
        float QuadraticAttenuation => 0;
        float AttenuationVisualizerThreshold => 0.05f;
        Vector3 AttenuationVisualizerOrientation => default;
        string ProxyNifAsset => "urn:llid:4cd225c8-0000-0000-0000-000000000000";
        float DepthBias => 0.98f;
    }
}
