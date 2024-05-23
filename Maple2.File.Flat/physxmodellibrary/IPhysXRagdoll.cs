using System.Collections.Generic;

namespace Maple2.File.Flat.physxmodellibrary {
    public interface IPhysXRagdoll : IPhysXProp {
        string ModelName => "PhysXRagdoll";
        IDictionary<string, string> PhysicalSequences => new Dictionary<string, string>();
    }
}
