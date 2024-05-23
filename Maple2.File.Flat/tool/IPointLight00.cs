using System.Drawing;
using System.Numerics;
using Maple2.File.Flat.beastmodellibrary;

namespace Maple2.File.Flat.tool {
    public interface IPointLight00 : IBeastPointLight {
        string ModelName => "PointLight00";
        Color DiffuseColor => Color.FromArgb(255, 255, 0, 0);
        Color SpecularColor => Color.FromArgb(255, 255, 0, 0);
        float ProxyScale => 1;
        Vector3 Position => new Vector3(119.9057f, 34.383858f, 300.99634f);
        string ShadowTechnique => "NiPCFShadowTechnique";
        ushort SizeHint => 2048;
        bool StrictlyObserveSizeHint => true;
    }
}
