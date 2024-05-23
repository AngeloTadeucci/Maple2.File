using System.Drawing;
using System.Numerics;
using Maple2.File.Flat.beastmodellibrary;

namespace Maple2.File.Flat.tool {
    public interface ISpotLight00 : IBeastSpotLight {
        string ModelName => "SpotLight00";
        Color DiffuseColor => Color.FromArgb(255, 255, 255, 0);
        Color SpecularColor => Color.FromArgb(255, 255, 255, 0);
        float Dimmer => 0.5f;
        float ProxyScale => 1;
        Vector3 Position => new Vector3(142.47716f, -194.19305f, 765.75256f);
        Vector3 Rotation => new Vector3(180, 90, 180);
        string ShadowTechnique => "NiPCFShadowTechnique";
        ushort SizeHint => 2048;
        bool StrictlyObserveSizeHint => true;
    }
}
