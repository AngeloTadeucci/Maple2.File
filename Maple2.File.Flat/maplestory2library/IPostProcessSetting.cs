namespace Maple2.File.Flat.maplestory2library {
    public interface IPostProcessSetting : IMapEntity {
        string ModelName => "PostProcessSetting";
        float Common_NearToFar => 1000;
        float AA_EdgeSmoothDepthWeight => 1000;
        float DOF_Dist => 0.01f;
        float DOF_Max => 0.2f;
        float Bloom_BrightPassThreshold => 1.1f;
        float Bloom_BrightPassOffset => 6;
        float Bloom_MiddleGray => 0.54f;
        float Bloom_Scale => 0.4f;
        float Bloom_AdaptationScale => 0.98f;
        float SSAO_DefaultOcclusion => 0.5f;
        float SSAO_DeltaScaleMultiplier => 0.5f;
        float SSAO_KernelRadiusMultiplier => 3;
        float SSAO_KernelSphereRadius => 200;
        float AA_EdgeSmoothNormalWeight => 20;
    }
}
