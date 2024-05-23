using System.Drawing;
using System.Numerics;

namespace Maple2.File.Flat.standardmodellibrary {
    public interface IWhitebox : IRenderable, ILightable, IShadowable, IBakeable {
        string ModelName => "Whitebox";
        Vector3 ShapeDimensions => default;
        Color Diffuse => Color.FromArgb(255, 255, 255, 255);
        bool SnapPoints => true;
        bool Walkable => true;
        bool RuntimeRender => true;
    }
}
