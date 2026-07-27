using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2InteractActor : IActor, IMS2InteractObject, I3DProxy, IMS2MapProperties {
        string ModelName => "MS2InteractActor";
        string reactableSequenceName => "0";
        bool IsVisible => true;
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
        bool MinimapInVisible => true;
        bool Transparency => true;
        bool UseInstancing => false;
        // Manually added: a handful of MS2InteractActor entities double as NPC spawn points and
        // carry the SpawnPointNPC property set (e.g. 11000119_MS2InteractActor_Moonrabbit on
        // 80000022_bonus). Neither the flat definition nor any mixin declares them, so they are
        // patched into the type index by RuntimeClassLookup the same way MS2Actor's are.
        [Obsolete("This property should not exist")]
        IDictionary<string, string> NpcList => new Dictionary<string, string>();
        [Obsolete("This property should not exist")]
        int SpawnPointID => 0;
        [Obsolete("This property should not exist")]
        float SpawnRadius => 0;
        [Obsolete("This property should not exist")]
        uint NpcCount => 0;
    }
}
