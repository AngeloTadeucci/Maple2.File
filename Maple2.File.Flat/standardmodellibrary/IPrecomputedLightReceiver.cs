namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPrecomputedLightReceiver : IPrecomputedLighting {
        string ModelName => "PrecomputedLightReceiver";
        bool UseLightProbes => false;
    }
}
