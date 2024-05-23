using System.Numerics;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2RegionSpawn : IMS2RegionSpawnBase {
        string ModelName => "MS2RegionSpawn";
        Vector3 VisualizeCube => new Vector3(150, 150, 150);
        Vector3 VisualizeOffset => new Vector3(0, 0, 75);
        float SpawnRadius => 0;
    }
}
