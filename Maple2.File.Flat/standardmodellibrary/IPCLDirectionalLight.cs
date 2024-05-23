namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPCLDirectionalLight : IPrecomputedLightConfig, IDirectionalLight {
        string ModelName => "PCLDirectionalLight";
        bool CastShadows => true;
    }
}
