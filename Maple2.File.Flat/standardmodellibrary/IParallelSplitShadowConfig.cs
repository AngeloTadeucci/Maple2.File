namespace Maple2.File.Flat.standardmodellibrary {
    public interface IParallelSplitShadowConfig : IMapEntity {
        string ModelName => "ParallelSplitShadowConfig";
        bool PSSMEnabled => true;
        bool SceneDependentFrustums => false;
        uint SliceCount => 4;
        float SliceDistanceExponentFactor => 0.5f;
        float SliceTransitionLength => 300;
        float SliceTransitionNoiseGranularity => 0.05f;
        bool SliceTransitions => false;
        bool SuppressShimmer => true;
        bool UseCustomFarPlane => false;
        float CustomFarPlane => 10000;
        float CameraDistanceScaleFactor => 5;
    }
}
