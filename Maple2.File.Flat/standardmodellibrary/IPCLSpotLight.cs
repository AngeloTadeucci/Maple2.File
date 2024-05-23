namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPCLSpotLight : ISpotLight, IPrecomputedLightConfig {
        string ModelName => "PCLSpotLight";
        bool CastShadows => true;
    }
}
