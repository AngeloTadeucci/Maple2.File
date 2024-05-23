using System.Drawing;
using System.Numerics;

namespace Maple2.File.Flat.tool {
    public interface IToolPointLight01 : IToolPointLight {
        string ModelName => "ToolPointLight01";
        Color DiffuseColor => Color.FromArgb(255, 0, 255, 0);
        Color SpecularColor => Color.FromArgb(255, 0, 255, 0);
        Vector3 Position => new Vector3(-167.31143f, -483.07828f, 300.99634f);
    }
}
