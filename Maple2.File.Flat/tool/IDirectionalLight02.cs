using System.Numerics;
using Maple2.File.Flat.beastmodellibrary;

namespace Maple2.File.Flat.tool {
    public interface IDirectionalLight02 : IBeastDirectionalLight {
        string ModelName => "DirectionalLight02";
        float Dimmer => 0.3f;
        float Range => 12000;
        float ProxyScale => 1;
        Vector3 Position => new Vector3(424.55194f, 0, 532);
        Vector3 Rotation => new Vector3(149.26126f, 23.578857f, 213.63934f);
        string ShadowTechnique => "NiPCFShadowTechnique";
        ushort SizeHint => 2048;
        bool StrictlyObserveSizeHint => true;
    }
}
