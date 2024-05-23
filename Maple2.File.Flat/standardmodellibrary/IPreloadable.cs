namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPreloadable : IMapEntity {
        string ModelName => "Preloadable";
        bool PreloadAssets => true;
    }
}
