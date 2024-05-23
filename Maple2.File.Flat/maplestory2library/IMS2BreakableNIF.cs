using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2BreakableNIF : IMS2Breakable, IMS2MapProperties, IMesh {
        string ModelName => "MS2BreakableNIF";
        Vector3 moveDirection => default;
        float moveTimeOffset => 0;
        float moveDistance => 0;
        float moveDuration => 0;
        float moveStopDurationS => 0;
        float moveStopDurationE => 0;
        int moveRoundType => 0;
        bool cloudAsset => false;
        uint TriggerBreakableID => 0;
        bool Enabled => false;
        bool reactionArrow => false;
        bool NxCollision => false;
        bool MinimapInVisible => false;
        bool IsStatic => true;
    }
}
