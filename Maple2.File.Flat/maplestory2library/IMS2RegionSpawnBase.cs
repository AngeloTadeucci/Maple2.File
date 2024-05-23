using System.Drawing;
using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2RegionSpawnBase : I3DProxy {
        string ModelName => "MS2RegionSpawnBase";
        int SpawnPointID => 0;
        Vector3 BattleField => default;
        Color BattleFieldColor => Color.FromArgb(255, 199, 20, 20);
        float SpawnTypeID => 0;
        bool UseRotAsSpawnDir => false;
    }
}
