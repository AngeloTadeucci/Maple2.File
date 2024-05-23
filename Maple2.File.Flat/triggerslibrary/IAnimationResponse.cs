using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.triggerslibrary {
    public interface IAnimationResponse : IAbstractTriggerResponse, IActor {
        string ModelName => "AnimationResponse";
        string TriggeredSequence => "";
    }
}
