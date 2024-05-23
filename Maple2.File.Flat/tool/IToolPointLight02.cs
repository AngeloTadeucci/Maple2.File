using System.Drawing;
using System.Numerics;

namespace Maple2.File.Flat.tool {
    public interface IToolPointLight02 : IToolPointLight {
        string ModelName => "ToolPointLight02";
        Color DiffuseColor => Color.FromArgb(255, 0, 0, 255);
        Color SpecularColor => Color.FromArgb(255, 0, 0, 255);
        Vector3 Position => new Vector3(515.7835f, -426.59235f, 300.99634f);
    }
}
