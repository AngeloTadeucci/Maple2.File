namespace Maple2.File.Flat.triggerslibrary {
    public interface ITouchSource : IAbstractTriggerSource {
        string ModelName => "TouchSource";
        bool isTouchable => true;
        string TriggerID => "Touched";
    }
}
