using System.Numerics;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2PropMovable : IMS2PropBase {
        string ModelName => "MS2PropMovable";
        Vector2 RestrictAngle => new Vector2(30, 45);
        Vector2 MovementSpeed => new Vector2(80, 100);
    }
}
