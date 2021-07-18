using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.physxmodellibrary {
    public interface IPhysXTerrain : ITerrain {
        string SceneName => "PhysXDefaultSceneName";
        ushort PhysXTerrainMaterialBaseIndex => 20;
    }
}
