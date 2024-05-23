using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IBeastAmbientLight : IAmbientLight, IPrecomputedLightConfig {
        string ModelName => "BeastAmbientLight";
    }
}
