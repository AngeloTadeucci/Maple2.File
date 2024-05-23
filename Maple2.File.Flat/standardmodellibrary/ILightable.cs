namespace Maple2.File.Flat.standardmodellibrary {
    public interface ILightable : IMapEntity {
        string ModelName => "Lightable";
        uint MaxDirectionalLights => 3;
        uint MaxPointLights => 3;
        uint MaxSpotLights => 2;
    }
}
