namespace Maple2.File.Flat.triggerslibrary {
    public interface IDelayedSpawnResponse : ISpawnResponse {
        string ModelName => "DelayedSpawnResponse";
        float SpawnDelay => 0;
    }
}
