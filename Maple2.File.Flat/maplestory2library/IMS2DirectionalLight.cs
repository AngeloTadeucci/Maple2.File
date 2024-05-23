using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2DirectionalLight : IDirectionalLight {
        string ModelName => "MS2DirectionalLight";
        float Dimmer => 0.8f;
        float ProxyScale => 1;
        Vector3 Rotation => new Vector3(68.91f, 11.54f, 300.75f);
        bool CastShadows => true;
        string ShadowTechnique => "NiPCFShadowTechnique";
        ushort SizeHint => 2048;
        float DepthBias => 0.001f;
    }
}
