using Maple2.File.Flat.beastmodellibrary;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2Beast : IBeastMeshTextureBakeSettings, IBeastMeshVertexBakeSettings, IBeastRenderStats, IBeastBakeType, IPrecomputedLightReceiver {
        string ModelName => "MS2Beast";
    }
}
