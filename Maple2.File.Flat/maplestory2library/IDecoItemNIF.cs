using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IDecoItemNIF : IMesh {
        string ModelName => "DecoItemNIF";
        bool IsCastingShadow => false;
        bool IsReceivingShadow => false;
    }
}
