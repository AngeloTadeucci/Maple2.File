namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPrecomputedLighting : IMapEntity {
        string ModelName => "PrecomputedLighting";
        bool UseForPrecomputedLighting => true;
    }
}
