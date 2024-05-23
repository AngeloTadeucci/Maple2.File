namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastFinalGatherSettings : IMapEntity {
        string ModelName => "BeastFinalGatherSettings";
        ushort ilbFGNumRays => 300;
        float ilbFGContrastThreshold => 0.1f;
        ushort ilbFGDepth => 1;
        bool ilbFGSampleVisibility => false;
    }
}
