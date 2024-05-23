using System.Drawing;
using System.Numerics;

namespace Maple2.File.Flat.tool {
    public interface IToolDirectionalLight01 : IToolDirectionalLight {
        string ModelName => "ToolDirectionalLight01";
        Color DiffuseColor => Color.FromArgb(255, 0, 255, 0);
        Color SpecularColor => Color.FromArgb(255, 0, 255, 0);
        Vector3 Position => new Vector3(197.57176f, 0, 532);
        Vector3 Rotation => new Vector3(152.37195f, 48.96411f, 270.83228f);
    }
}
