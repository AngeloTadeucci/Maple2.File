namespace Maple2.File.Flat.standardmodellibrary {
    public interface ISpotLight : IPointLight {
        string ModelName => "SpotLight";
        float OuterSpotAngle => 22.5f;
        float InnerSpotAngle => 21.5f;
        float SpotExponent => 1;
        string ProxyNifAsset => "urn:llid:83383ddc-0000-0000-0000-000000000000";
        float DepthBias => 0;
    }
}
