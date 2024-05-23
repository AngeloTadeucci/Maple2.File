namespace Maple2.File.Flat.maplestory2library {
    public interface ISpawnPointItem : ISpawnPoint {
        string ModelName => "SpawnPointItem";
        uint globalDropLevel => 1;
        uint dropRank => 1;
        string globalDropBoxId => "";
        string individualDropBoxId => "";
        float LifeTime => 0;
    }
}
