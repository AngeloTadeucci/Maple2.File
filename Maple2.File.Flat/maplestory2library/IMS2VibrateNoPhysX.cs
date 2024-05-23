using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2VibrateNoPhysX : IMS2MapProperties, IMS2Vibrate, IMesh {
        string ModelName => "MS2VibrateNoPhysX";
        bool IsStatic => true;
    }
}
