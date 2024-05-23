namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2TimeAmbSetting : IMapEntity {
        string ModelName => "MS2TimeAmbSetting";
        bool timeShowEnabled => false;
        float dayVisibleTiming => 0;
        float nightVisibleTiming => 0;
        string dayAmb => "";
        string nightAmb => "";
    }
}
