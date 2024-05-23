using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IGameObject : IActor, IMS2CameraSubject {
        string ModelName => "GameObject";
        bool IsReceivingShadow => false;
    }
}
