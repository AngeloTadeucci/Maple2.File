using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastDirectionalLight : IPCLDirectionalLight, IBeastLight {
        string ModelName => "BeastDirectionalLight";
        float ilbShadowAngle => 0;
    }
}
