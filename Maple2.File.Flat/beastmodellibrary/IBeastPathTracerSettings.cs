namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastPathTracerSettings : IMapEntity {
        string ModelName => "BeastPathTracerSettings";
        float ilbPTAccuracy => 1;
        float ilbPTCachePointSpacing => 0;
        bool ilbPTSampleVisibilty => false;
    }
}
