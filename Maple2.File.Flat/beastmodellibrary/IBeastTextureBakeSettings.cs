namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastTextureBakeSettings : IMapEntity {
        string ModelName => "BeastTextureBakeSettings";
        string ilbMinTextureSamples => "1";
        string ilbMaxTextureSamples => "4";
        float ilbSamplingContrastThreshold => 0.1f;
        string ilbSamplingFilterType => "Gauss";
        float ilbSamplingFilterSize => 2.2f;
        bool ilbConservativeRasterization => false;
    }
}
