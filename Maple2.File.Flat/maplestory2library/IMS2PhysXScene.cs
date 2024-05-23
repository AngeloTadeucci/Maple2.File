using System.Numerics;
using Maple2.File.Flat.physxmodellibrary;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2PhysXScene : IPhysXScene, I3DProxy {
        string ModelName => "MS2PhysXScene";
        Vector3 Gravity => new Vector3(0, 0, -40);
        float ScaleFactor => 100;
    }
}
