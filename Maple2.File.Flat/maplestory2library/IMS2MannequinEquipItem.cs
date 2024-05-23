namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2MannequinEquipItem : IMS2EquipItem, IExceptLightService {
        string ModelName => "MS2MannequinEquipItem";
        bool IsVisible => false;
        bool IsCastingShadow => false;
    }
}
