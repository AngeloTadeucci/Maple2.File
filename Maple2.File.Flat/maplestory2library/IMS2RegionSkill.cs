using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2RegionSkill : I3DProxy {
        string ModelName => "MS2RegionSkill";
        int skillID => 0;
        int skillLevel => 0;
        int Interval => 0;
        float VRadius => 0;
        int count => 0;
        int friendly => 0;
        Vector3 VCube => default;
        Vector3 VCubeOffset => new Vector3(0, 0, 75);
        string ProxyNifAsset => "urn:llid:6506bb15-0000-0000-0000-000000000000";
    }
}
