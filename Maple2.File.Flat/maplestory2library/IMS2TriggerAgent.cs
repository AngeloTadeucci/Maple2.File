using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2TriggerAgent : IMS2TriggerObject, I3DProxy {
        string ModelName => "MS2TriggerAgent";
        bool Enabled => false;
    }
}
