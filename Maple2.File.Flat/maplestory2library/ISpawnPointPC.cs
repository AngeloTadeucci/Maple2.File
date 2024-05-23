namespace Maple2.File.Flat.maplestory2library {
    public interface ISpawnPointPC : ISpawnPoint {
        string ModelName => "SpawnPointPC";
        int SpawnPointID => 0;
        bool Enable => true;
        string ProxyNifAsset => "urn:llid:f3e115f9-0000-0000-0000-000000000000";
    }
}
