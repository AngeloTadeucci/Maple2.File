using System.Numerics;

namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPlaceable : IMapEntity {
        string ModelName => "Placeable";
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
    }
}
