using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Maple2.File.Flat.standardmodellibrary {
    public interface ILight : I3DProxy, IBakeable {
        string ModelName => "Light";
        Color AmbientColor => Color.FromArgb(255, 0, 0, 0);
        Color DiffuseColor => Color.FromArgb(255, 255, 255, 255);
        Color SpecularColor => Color.FromArgb(255, 255, 255, 255);
        float Dimmer => 1;
        float Range => 10000;
        Vector3 RangeVisualizerOrientation => default;
        float LightPriority => 50;
        bool UpdateLightingOnMove => false;
        IDictionary<string, string> AlwaysAffectedByLight => new Dictionary<string, string>();
        IDictionary<string, string> NeverAffectedByLight => new Dictionary<string, string>();
        float ProxyScale => 0.01f;
        bool IsStatic => true;
    }
}
