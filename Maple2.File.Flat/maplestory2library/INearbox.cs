using System.Drawing;
using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface INearbox : IWhitebox {
        string ModelName => "Nearbox";
        uint ExcluderBrightness => 100;
        Vector3 ShapeDimensions => new Vector3(100, 100, 100);
        Color Diffuse => Color.FromArgb(128, 4, 4, 4);
        bool Walkable => false;
        bool RuntimeRender => false;
        bool IsCastingShadow => false;
        bool IsReceivingShadow => false;
    }
}
