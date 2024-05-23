using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2SalePost : IMS2MeshNoPhysX, INameable, I3DProxy {
        string ModelName => "MS2SalePost";
        int HeightLimit => 3;
        string ForSaleAsset => "";
        string SoldOutAsset => "";
        string WaitingAsset => "";
        bool IsVisible => true;
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
    }
}
