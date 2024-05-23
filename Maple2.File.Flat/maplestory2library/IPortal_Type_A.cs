using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IPortal_Type_A : IPortal, I3DProxy {
        string ModelName => "Portal_Type_A";
        string NifAsset => "urn:llid:dcc516bf-0000-0000-0000-000000000000";
        bool IsVisible => true;
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 0.7f;
    }
}
