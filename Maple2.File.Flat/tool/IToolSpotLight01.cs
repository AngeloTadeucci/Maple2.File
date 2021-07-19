using System.Drawing;
using System.Numerics;

namespace Maple2.File.Flat.tool {
    public interface IToolSpotLight01 : IToolSpotLight {
        string ModelName => "ToolSpotLight01";
        Color DiffuseColor => Color.FromArgb(255, 0, 255, 255);
        Color SpecularColor => Color.FromArgb(255, 0, 255, 255);
        Vector3 Position => new Vector3(142.47716f, -194.19305f, 765.75256f);
        Vector3 Rotation => new Vector3(180, 90, 180);
    }
}
