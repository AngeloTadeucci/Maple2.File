using System.Drawing;
using System.Numerics;

namespace Maple2.File.Flat.tool {
    public interface IToolDirectionalLight00 : IToolDirectionalLight {
        string ModelName => "ToolDirectionalLight00";
        Color DiffuseColor => Color.FromArgb(255, 255, 0, 0);
        Color SpecularColor => Color.FromArgb(255, 255, 0, 0);
        Vector3 Position => new Vector3(0, 0, 532);
        Vector3 Rotation => new Vector3(55, 35, 320);
    }
}
