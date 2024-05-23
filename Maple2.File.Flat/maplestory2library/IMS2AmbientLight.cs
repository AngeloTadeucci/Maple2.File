using System.Drawing;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2AmbientLight : IAmbientLight {
        string ModelName => "MS2AmbientLight";
        Color AmbientColor => Color.FromArgb(255, 255, 255, 255);
        float Dimmer => 0.8f;
        float ProxyScale => 1;
    }
}
