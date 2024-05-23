using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.physxmodellibrary {
    public interface IPhysXWhiteboxTrigger : IPhysXTrigger, IPhysXBox, IWhitebox {
        string ModelName => "PhysXWhiteboxTrigger";
        bool AnchorAtBase => false;
        Vector3 ShapeDimensions => new Vector3(1, 1, 1);
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
    }
}
