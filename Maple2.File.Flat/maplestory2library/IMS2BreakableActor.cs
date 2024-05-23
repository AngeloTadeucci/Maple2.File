using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2BreakableActor : IActor, IMS2TextKeyCallback, IMS2Breakable {
        string ModelName => "MS2BreakableActor";
        Vector3 moveDirection => default;
        float moveTimeOffset => 0;
        float moveDistance => 0;
        float moveDuration => 0;
        float moveStopDurationS => 0;
        float moveStopDurationE => 0;
        int moveRoundType => 0;
        bool cloudAsset => false;
        uint TriggerBreakableID => 0;
        string InitialSequence => "Idle_A";
        Vector3 ShapeDimensions => new Vector3(150, 150, 150);
        int SoundMaterial => 1;
    }
}
