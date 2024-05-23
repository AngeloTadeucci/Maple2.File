using System.Numerics;
using Maple2.File.Flat.beastmodellibrary;

namespace Maple2.File.Flat.tool {
    public interface IDirectionalLight01 : IBeastDirectionalLight {
        string ModelName => "DirectionalLight01";
        float Dimmer => 0.3f;
        float Range => 12000;
        float ProxyScale => 1;
        Vector3 Position => new Vector3(197.57176f, 0, 532);
        Vector3 Rotation => new Vector3(152.37195f, 48.96411f, 270.83228f);
        string ShadowTechnique => "NiPCFShadowTechnique";
        ushort SizeHint => 2048;
        bool StrictlyObserveSizeHint => true;
    }
}
