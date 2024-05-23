using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface ILookAtTarget : I3DProxy {
        string ModelName => "LookAtTarget";
        float LookAtDistance => 700;
        float LookAtDuration => 5000;
        string ProxyNifAsset => "urn:llid:1754aa16-0000-0000-0000-000000000000";
    }
}
