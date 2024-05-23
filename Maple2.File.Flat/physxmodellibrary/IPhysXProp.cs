using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.physxmodellibrary {
    public interface IPhysXProp : IPlaceable {
        string ModelName => "PhysXProp";
        string SceneName => "PhysXDefaultSceneName";
        uint State => 0;
        ushort PropCollisionGroup => 0;
        bool InteractWithTriggers => false;
    }
}
