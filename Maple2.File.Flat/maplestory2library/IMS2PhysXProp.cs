using System.Numerics;
using Maple2.File.Flat.physxmodellibrary;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2PhysXProp : IPhysXProp, IMesh, IMS2MapProperties, IMS2Vibrate, IMS2InstallProperties, IMS2PathEngineTOK {
        string ModelName => "MS2PhysXProp";
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
        bool IsStatic => true;
    }
}
