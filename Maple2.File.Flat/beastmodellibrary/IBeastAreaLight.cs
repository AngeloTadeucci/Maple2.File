using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastAreaLight : IPointLight, IBeastLight, IPrecomputedLightConfig {
        string ModelName => "BeastAreaLight";
        bool CastShadows => true;
        bool LightNonPCLObjectsAtRuntime => false;
    }
}
