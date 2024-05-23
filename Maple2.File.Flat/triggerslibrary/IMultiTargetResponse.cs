using System.Collections.Generic;

namespace Maple2.File.Flat.triggerslibrary {
    public interface IMultiTargetResponse : IAbstractTriggerResponse {
        string ModelName => "MultiTargetResponse";
        IDictionary<string, string> TargetList => new Dictionary<string, string>();
    }
}
