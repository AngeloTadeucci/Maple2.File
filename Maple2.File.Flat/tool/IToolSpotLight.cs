using Maple2.File.Flat.beastmodellibrary;

namespace Maple2.File.Flat.tool {
    public interface IToolSpotLight : IBeastSpotLight {
        string ModelName => "ToolSpotLight";
        float Dimmer => 0.5f;
        float ProxyScale => 1;
        string ShadowTechnique => "NiPCFShadowTechnique";
        bool StrictlyObserveSizeHint => true;
        bool LightPCLObjectsAtRuntime => true;
    }
}
