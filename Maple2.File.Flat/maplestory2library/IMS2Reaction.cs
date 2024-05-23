using System.Numerics;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2Reaction : IMapEntity {
        string ModelName => "MS2Reaction";
        bool reactionEnter => false;
        bool reactionArrow => false;
        bool Enabled => true;
        string reactionSequenceName => "";
        Vector3 ShapeDimensions => default;
        float lastUpdatedTime => 0;
        float updateInterval => 1;
    }
}
