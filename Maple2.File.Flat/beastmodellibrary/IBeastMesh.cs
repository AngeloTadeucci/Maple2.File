using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastMesh : IBeastMeshTextureBakeSettings, IBeastMeshVertexBakeSettings, IBeastRenderStats, IBeastBakeType, IPCLMesh {
        string ModelName => "BeastMesh";
        float ilbEmissiveScale => 1;
    }
}
