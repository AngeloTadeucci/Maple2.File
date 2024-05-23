using System.Drawing;
using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface ICameraTargetBounding : IWhitebox {
        string ModelName => "CameraTargetBounding";
        string ShapeType => "";
        Vector3 ShapeDimensions => new Vector3(100, 100, 100);
        Color Diffuse => Color.FromArgb(255, 0, 155, 0);
        bool Walkable => false;
        bool RuntimeRender => false;
        bool IsCastingShadow => false;
        bool IsReceivingShadow => false;
        bool IsStatic => true;
    }
}
