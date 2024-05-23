using System.Numerics;
using Maple2.File.Flat.physxmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2PropCollide : IMS2PropBase, IPhysXProp {
        string ModelName => "MS2PropCollide";
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
    }
}
