using Maple2.File.Flat.beastmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IEffectPointLight : IBeastPointLight {
        string ModelName => "EffectPointLight";
        bool LightPCLObjectsAtRuntime => true;
        bool UseForPrecomputedLighting => false;
        float Range => 1000;
        float LightPriority => 30;
        bool UpdateLightingOnMove => true;
        float ProxyScale => 1;
        bool IsStatic => false;
        bool CastShadows => false;
    }
}
