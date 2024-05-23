using System.Collections.Generic;

namespace Maple2.File.Flat.standardmodellibrary {
    public interface IInputHandler : IBaseEntity {
        string ModelName => "InputHandler";
        IDictionary<string, string> NormalEventMap => new Dictionary<string, string>();
        bool InputsEnabled => true;
        IDictionary<string, string> ImmediateEventMap => new Dictionary<string, string>();
    }
}
