namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastQualityPresetProductionGI : IBeastQualitySettings {
        string ModelName => "BeastQualityPresetProductionGI";
        ushort ilbFGNumRays => 1000;
        bool ilbPTSampleVisibilty => true;
    }
}
