using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2NolightableMesh : IMesh, IExceptLightService {
        string ModelName => "MS2NolightableMesh";
        bool IsCastingShadow => false;
        bool IsReceivingShadow => false;
    }
}
