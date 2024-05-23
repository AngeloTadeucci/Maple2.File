using System.Drawing;
using System.Numerics;

namespace Maple2.File.Flat.tool {
    public interface IToolPointLight00 : IToolPointLight {
        string ModelName => "ToolPointLight00";
        Color DiffuseColor => Color.FromArgb(255, 255, 0, 0);
        Color SpecularColor => Color.FromArgb(255, 255, 0, 0);
        Vector3 Position => new Vector3(119.9057f, 34.383858f, 300.99634f);
    }
}
