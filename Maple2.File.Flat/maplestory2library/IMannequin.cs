namespace Maple2.File.Flat.maplestory2library {
    public interface IMannequin : IGameObject, IExceptLightService {
        string ModelName => "Mannequin";
        bool IsVisible => false;
        bool IsCastingShadow => false;
    }
}
