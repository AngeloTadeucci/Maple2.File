namespace Maple2.File.Flat.standardmodellibrary {
    public interface IShadowable : IMapEntity {
        string ModelName => "Shadowable";
        bool IsCastingShadow => true;
        bool IsReceivingShadow => true;
    }
}
