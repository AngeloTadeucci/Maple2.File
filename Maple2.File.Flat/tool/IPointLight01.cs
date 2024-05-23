using System.Drawing;
using System.Numerics;
using Maple2.File.Flat.beastmodellibrary;

namespace Maple2.File.Flat.tool {
    public interface IPointLight01 : IBeastPointLight {
        string ModelName => "PointLight01";
        Color DiffuseColor => Color.FromArgb(255, 0, 255, 0);
        Color SpecularColor => Color.FromArgb(255, 0, 255, 0);
        float ProxyScale => 1;
        Vector3 Position => new Vector3(-167.31143f, -483.07828f, 300.99634f);
        string ShadowTechnique => "NiPCFShadowTechnique";
        ushort SizeHint => 2048;
        bool StrictlyObserveSizeHint => true;
    }
}
