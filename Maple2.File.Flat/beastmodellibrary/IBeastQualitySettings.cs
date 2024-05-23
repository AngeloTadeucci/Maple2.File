namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastQualitySettings : IBeastIntegratorSettings, IBeastFinalGatherSettings, IBeastPathTracerSettings, IBeastTextureBakeSettings, IBeastVertexBakeSettings, IBeastBakePreferences {
        string ModelName => "BeastQualitySettings";
    }
}
