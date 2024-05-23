using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2LiftableTargetGuide : I3DProxy {
        string ModelName => "MS2LiftableTargetGuide";
        int liftableTarget => 0;
        string effectXml => "BG/Common/Eff_co_targetBoxGuide.xml";
        string ProxyNifAsset => "urn:llid:f3e115f9-0000-0000-0000-000000000000";
        float ProxyScale => 0.5f;
    }
}
