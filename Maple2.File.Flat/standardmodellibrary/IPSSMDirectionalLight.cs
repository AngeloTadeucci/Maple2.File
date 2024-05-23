namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPSSMDirectionalLight : IDirectionalLight, IParallelSplitShadowConfig {
        string ModelName => "PSSMDirectionalLight";
        bool CastShadows => true;
    }
}
