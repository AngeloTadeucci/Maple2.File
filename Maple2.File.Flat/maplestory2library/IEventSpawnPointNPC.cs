namespace Maple2.File.Flat.maplestory2library {
    public interface IEventSpawnPointNPC : ISpawnPointNPC {
        string ModelName => "EventSpawnPointNPC";
        float LifeTime => 0;
        string SpawnAnimation => "Regen_A";
        bool UseRotAsSpawnDir => true;
        int SpawnPointID => 101;
    }
}
