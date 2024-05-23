namespace Maple2.File.Flat.physxmodellibrary {
    public interface IPhysXTrigger : IMapEntity {
        string ModelName => "PhysXTrigger";
        bool TriggerOnEnter => true;
        bool TriggerOnStay => false;
        float TriggerMinInterval => 0.1f;
        bool TriggerOnLeave => true;
        bool AnchorAtBase => true;
    }
}
