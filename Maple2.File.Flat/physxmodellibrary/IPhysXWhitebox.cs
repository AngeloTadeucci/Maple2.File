using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.physxmodellibrary {
    public interface IPhysXWhitebox : IWhitebox, IPhysXProp {
        string ModelName => "PhysXWhitebox";
        float Density => 1;
        bool DynamicallySimulate => false;
        float Friction => 1;
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
    }
}
