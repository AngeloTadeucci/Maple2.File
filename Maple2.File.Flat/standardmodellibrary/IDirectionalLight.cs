namespace Maple2.File.Flat.standardmodellibrary {
    public interface IDirectionalLight : ILight, IShadowGenerator {
        string ModelName => "DirectionalLight";
        string ProxyNifAsset => "urn:llid:2fef7ea2-0000-0000-0000-000000000000";
        bool RenderBackfaces => false;
        bool UseDefaultDepthBias => false;
        float DepthBias => 0.002f;
    }
}
