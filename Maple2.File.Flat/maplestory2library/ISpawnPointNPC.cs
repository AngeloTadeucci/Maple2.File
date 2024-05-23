using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Maple2.File.Flat.maplestory2library {
    public interface ISpawnPointNPC : ISpawnPoint {
        string ModelName => "SpawnPointNPC";
        int SpawnPointID => 0;
        float SpawnRadius => 0;
        uint NpcCount => 0;
        IDictionary<string, string> NpcList => new Dictionary<string, string>();
        float RegenCheckTime => 10;
        Vector3 VisualizeCube => new Vector3(150, 150, 150);
        Vector3 VisualizeOffset => new Vector3(0, 0, 75);
        string PatrolData => "00000000-0000-0000-0000-000000000000";
        bool PeaceRestore => true;
        Vector3 BattleField => default;
        Color BattleFieldColor => Color.FromArgb(255, 199, 20, 20);
        bool dayActive => true;
        float dayTiming => 0;
        bool nightDie => false;
        bool nightActive => true;
        float nightTiming => 0;
        bool dayDie => false;
        uint TeamID => 0;
        bool IsSpawnOnFieldCreate => true;
    }
}
