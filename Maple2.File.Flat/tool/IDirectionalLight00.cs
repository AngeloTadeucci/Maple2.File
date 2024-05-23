using System.Numerics;
using Maple2.File.Flat.beastmodellibrary;

namespace Maple2.File.Flat.tool {
    public interface IDirectionalLight00 : IBeastDirectionalLight {
        string ModelName => "DirectionalLight00";
        float Dimmer => 0.3f;
        float Range => 12000;
        float ProxyScale => 1;
        Vector3 Position => new Vector3(0, 0, 532);
        Vector3 Rotation => new Vector3(55, 35, 320);
        string ShadowTechnique => "NiPCFShadowTechnique";
        ushort SizeHint => 2048;
        bool StrictlyObserveSizeHint => true;
    }
}
