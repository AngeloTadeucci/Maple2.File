namespace Maple2.File.Flat.standardmodellibrary {
    public interface IBakeable : IMapEntity {
        string ModelName => "Bakeable";
        bool IsStatic => false;
    }
}
