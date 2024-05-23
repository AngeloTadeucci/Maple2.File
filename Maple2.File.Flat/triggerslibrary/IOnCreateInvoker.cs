using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.triggerslibrary {
    public interface IOnCreateInvoker : IOnCreateTriggerSource, IRemoteBehaviorResponse, IPlaceable {
        string ModelName => "OnCreateInvoker";
        uint ActivationCount => 0;
        uint MaxActivations => 1;
        string BehaviorName => "BeginPeriodic";
    }
}
