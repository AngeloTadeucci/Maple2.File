using System.Numerics;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2HealingRegionSkillSound : IMS2Sound, IMS2RegionSkill, IMS2Minimap {
        string ModelName => "MS2HealingRegionSkillSound";
        string soundEventID => "MS2Sound/Sound/AMB/11100037";
        string ProxyNifAsset => "urn:llid:6506bb15-0000-0000-0000-000000000000";
        float ProxyScale => 1;
        bool IsVisible => true;
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
        int skillID => 70000018;
        int skillLevel => 1;
        int Interval => 700;
        float VRadius => 300;
        int friendly => 1;
        Vector3 VCube => new Vector3(450, 450, 300);
    }
}
