using System.Collections.Generic;

namespace Maple2.File.Flat.standardmodellibrary {
    public interface ITimeOfDayEditable : IMapEntity {
        string ModelName => "TimeOfDayEditable";
        string TimeOfDayAssetPath => "";
        IDictionary<string, string> TimeOfDayAnimatablePropertyList => new Dictionary<string, string>();
    }
}
