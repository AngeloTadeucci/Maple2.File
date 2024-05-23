using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2TriggerModel : I3DProxy {
        string ModelName => "MS2TriggerModel";
        string XmlFilePath => "";
        int TriggerModelID => 0;
        string ProxyNifAsset => "urn:llid:d831beb8-0000-0000-0000-000000000000";
    }
}
