using Maple2.File.Flat.physxmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2PhysXWhitebox : IPhysXWhitebox, IMS2PathEngineTOK {
        string ModelName => "MS2PhysXWhitebox";
    }
}
