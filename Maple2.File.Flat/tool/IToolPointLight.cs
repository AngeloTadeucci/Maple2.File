using Maple2.File.Flat.beastmodellibrary;

namespace Maple2.File.Flat.tool {
    public interface IToolPointLight : IBeastPointLight {
        string ModelName => "ToolPointLight";
        bool LightPCLObjectsAtRuntime => true;
        float Range => 100000;
        float ProxyScale => 1;
        string ShadowTechnique => "NiPCFShadowTechnique";
        bool StrictlyObserveSizeHint => true;
    }
}
