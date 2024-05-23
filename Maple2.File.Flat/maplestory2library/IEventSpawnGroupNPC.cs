using System.Collections.Generic;

namespace Maple2.File.Flat.maplestory2library {
    public interface IEventSpawnGroupNPC : IEventSpawnPointNPC {
        string ModelName => "EventSpawnGroupNPC";
        string NpcGroupTag => "";
        IDictionary<string, int> NpcGroupCount => new Dictionary<string, int>();
        IDictionary<string, string> NpcGroupProbability => new Dictionary<string, string>();
    }
}
