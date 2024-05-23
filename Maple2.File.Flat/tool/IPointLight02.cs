using System.Drawing;
using System.Numerics;
using Maple2.File.Flat.beastmodellibrary;

namespace Maple2.File.Flat.tool {
    public interface IPointLight02 : IBeastPointLight {
        string ModelName => "PointLight02";
        Color DiffuseColor => Color.FromArgb(255, 0, 0, 255);
        Color SpecularColor => Color.FromArgb(255, 0, 0, 255);
        float ProxyScale => 1;
        Vector3 Position => new Vector3(515.7835f, -426.59235f, 300.99634f);
        string ShadowTechnique => "NiPCFShadowTechnique";
        ushort SizeHint => 2048;
        bool StrictlyObserveSizeHint => true;
    }
}
