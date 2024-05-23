using Maple2.File.Flat.physxmodellibrary;

namespace Maple2.File.Flat.triggerslibrary {
    public interface ICollisionTriggerSource : IAbstractTriggerSource, IPhysXTrigger, IPhysXShape {
        string ModelName => "CollisionTriggerSource";
        bool UseModelFilter => true;
        string ModelFilter => "Player";
        double TriggerCooldown => 1;
        double LastTriggerTime => -1;
        string TriggerID => "Collided";
    }
}
