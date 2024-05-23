using System.Drawing;
using System.Numerics;

namespace Maple2.File.Flat.tool {
    public interface IToolDirectionalLight02 : IToolDirectionalLight {
        string ModelName => "ToolDirectionalLight02";
        Color DiffuseColor => Color.FromArgb(255, 0, 0, 255);
        Color SpecularColor => Color.FromArgb(255, 0, 0, 255);
        Vector3 Position => new Vector3(424.55194f, 0, 532);
        Vector3 Rotation => new Vector3(149.26126f, 23.578857f, 213.63934f);
    }
}
