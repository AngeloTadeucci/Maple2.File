namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2TriggerSound : IMS2Sound, IMS2TriggerObject {
        string ModelName => "MS2TriggerSound";
        string SoundType => "BGM";
        bool Enabled => false;
        string soundEndXml => "";
        string soundStartXml => "";
    }
}
