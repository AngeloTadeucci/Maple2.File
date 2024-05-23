namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2TimeShowSetting : IMapEntity {
        string ModelName => "MS2TimeShowSetting";
        bool dayVisible => true;
        bool nightVisible => true;
        bool timeShowEnabled => false;
        float dayVisibleTiming => 0;
        float nightVisibleTiming => 0;
    }
}
