using Maple2.File.Flat.beastmodellibrary;

namespace Maple2.File.Flat.tool {
    public interface IToolDirectionalLight : IBeastDirectionalLight {
        string ModelName => "ToolDirectionalLight";
        float ilbShadowAngle => 3;
        bool LightPCLObjectsAtRuntime => true;
        float Dimmer => 0.3f;
        float Range => 100000;
        float ProxyScale => 1;
        string ShadowTechnique => "NiPCFShadowTechnique";
        bool StrictlyObserveSizeHint => true;
        ushort ilbShadowSamples => 16;
    }
}
