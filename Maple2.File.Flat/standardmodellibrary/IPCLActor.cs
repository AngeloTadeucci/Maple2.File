namespace Maple2.File.Flat.standardmodellibrary {
    public interface IPCLActor : IActor, IPrecomputedLightReceiver {
        string ModelName => "PCLActor";
        bool UseLightProbes => true;
    }
}
