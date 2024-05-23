using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.triggerslibrary {
    public interface ISpawnResponse : IAbstractTriggerResponse, IPlaceable {
        string ModelName => "SpawnResponse";
        string ModelToSpawn => "";
    }
}
