using System;

namespace Maple2.File.Flat.maplestory2library {
    public interface IEventSpawnPointItem : ISpawnPointItem {
        string ModelName => "EventSpawnPointItem";
        int SpawnPointID => 0;
        // Manually added
        [Obsolete("This property should not exist")]
        int dropID => 0;
    }
}
