using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IDropItemNIF : IMesh {
        string ModelName => "DropItemNIF";
        bool IsStatic => true;
        bool IsReceivingShadow => false;
    }
}
