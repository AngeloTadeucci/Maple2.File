using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2TombStone : IActor, IMS2TextKeyCallback, IMS2Breakable {
        string ModelName => "MS2TombStone";
        uint OwnerGameOID => 0;
        string SpawnAnimation => "co_obj_brk_tomb_ani_Regen_A";
        string HitAnimation => "co_obj_brk_tomb_ani_Damg_A";
        string KfmAsset => "urn:llid:2dd0b9b6-0000-0000-0000-000000000000";
        string InitialSequence => "co_obj_brk_tomb_ani_Idle_A";
        bool IsReceivingShadow => false;
        Vector3 ShapeDimensions => new Vector3(100, 100, 150);
        int SoundMaterial => 4;
        bool NxCollision => false;
    }
}
