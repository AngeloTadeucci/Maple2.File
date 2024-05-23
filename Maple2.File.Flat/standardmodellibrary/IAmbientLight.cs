using System.Drawing;

namespace Maple2.File.Flat.standardmodellibrary {
    public interface IAmbientLight : ILight {
        string ModelName => "AmbientLight";
        Color AmbientColor => Color.FromArgb(255, 128, 128, 128);
        Color DiffuseColor => Color.FromArgb(255, 0, 0, 0);
        Color SpecularColor => Color.FromArgb(255, 0, 0, 0);
        string ProxyNifAsset => "urn:llid:e0dc647e-0000-0000-0000-000000000000";
    }
}
