namespace Maple2.File.Flat.triggerslibrary {
    public interface IPeriodicTriggerSource : IAbstractTriggerSource {
        string ModelName => "PeriodicTriggerSource";
        uint StartDelay => 8000;
        float PeriodicInterval => 8000;
    }
}
