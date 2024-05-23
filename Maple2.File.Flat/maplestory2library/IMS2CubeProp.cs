using System;
using System.Numerics;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2CubeProp : IMS2PhysXProp, ICubeBrushable {
        string ModelName => "MS2CubeProp";
        int skillID => 0;
        int skillLevel => 0;
        ushort PropCollisionGroup => 9;
        Vector3 ShapeDimensions => default;
        string InstallStackable => "3,4,5";
        bool InstallWall => true;
        string InstallStackableD => "3,4,5";
        // Manually added
        [Obsolete("This property should not exist")]
        string ProxyNifAsset => "";
        [Obsolete("This property should not exist")]
        int Interval => 0;
        [Obsolete("This property should not exist")]
        int friendly => 0;
    }
}
