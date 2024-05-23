namespace Maple2.File.Flat.triggerslibrary {
    public interface IAbstractTriggerResponse : IMapEntity {
        string ModelName => "AbstractTriggerResponse";
        uint ActivationCount => 0;
        uint MaxActivations => 1;
    }
}
