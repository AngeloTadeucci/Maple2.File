using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.physxmodellibrary {
    public interface IPhysXShape : IPlaceable {
        string ModelName => "PhysXShape";
        Vector3 ShapeTranslation => default;
        Vector3 ShapeRotation => default;
        ushort ShapeCollisionGroup => 0;
        string ShapeType => "box";
        Vector3 ShapeDimensions => new Vector3(1, 1, 1);
        string SceneName => "PhysXDefaultSceneName";
    }
}
