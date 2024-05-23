using System.Numerics;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2InstallProperties : IMapEntity {
        string ModelName => "MS2InstallProperties";
        string InstallStackable => "0";
        uint InstallIndoor => 0;
        int InstallFuncCode => 0;
        int InstallObjCode => 0;
        bool InstallWall => false;
        string InstallPlaceable => "0";
        string InstallStackableD => "0";
        bool InstallUnchangeable => false;
        Vector3 InstallPortalOffset => default;
        bool InstallCannotStackAttach => false;
    }
}
