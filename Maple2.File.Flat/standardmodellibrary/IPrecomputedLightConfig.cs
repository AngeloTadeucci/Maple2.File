namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPrecomputedLightConfig : IPrecomputedLighting {
        string ModelName => "PrecomputedLightConfig";
        bool LightPCLObjectsAtRuntime => false;
        bool LightNonPCLObjectsAtRuntime => true;
    }
}
