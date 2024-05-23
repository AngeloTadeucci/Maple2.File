using System.Numerics;
using Maple2.File.Flat.beastmodellibrary;
using Maple2.File.Flat.physxmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2BeastPhysXProp : IPhysXProp, IBeastMesh, IMS2MapProperties, IMS2Vibrate {
        string ModelName => "MS2BeastPhysXProp";
        bool BeastIsCastingShadow => true;
        bool BeastIsReceivingShadow => true;
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
        bool IsStatic => true;
    }
}
