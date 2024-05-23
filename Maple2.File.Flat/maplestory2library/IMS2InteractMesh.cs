using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2InteractMesh : IMS2InteractObject, IMesh, I3DProxy, IMS2MapProperties {
        string ModelName => "MS2InteractMesh";
        string reactableAssetName => "";
        bool MinimapInVisible => true;
        bool IsVisible => true;
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
        bool Transparency => true;
        bool UseInstancing => false;
    }
}
