using System.Collections.Generic;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMultiSpawnPointNPC : ISpawnPointNPC {
        string ModelName => "MultiSpawnPointNPC";
        IDictionary<string, string> SpawnPositions => new Dictionary<string, string>();
        IDictionary<string, string> SpawnRotations => new Dictionary<string, string>();
    }
}
