namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPCLPointLight : IPrecomputedLightConfig, IPointLight {
        string ModelName => "PCLPointLight";
        bool CastShadows => true;
    }
}
