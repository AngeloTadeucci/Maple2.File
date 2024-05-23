using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2TriggerCamera : IMS2TriggerObject, ICamera {
        string ModelName => "MS2TriggerCamera";
        string XmlFilePath => "";
        bool Enabled => false;
        float StartInterpolationTime => 0;
        float EndInterpolationTime => 0;
        bool EnableCameraEffect => true;
        bool FixedLocationAfterEffect => false;
        uint StartInterpolator => 1;
        uint EndInterpolator => 1;
        float FOV => 40;
        float ProxyScale => 20;
    }
}
