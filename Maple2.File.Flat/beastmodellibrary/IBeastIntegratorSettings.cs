namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastIntegratorSettings : IMapEntity {
        string ModelName => "BeastIntegratorSettings";
        string ilbPrimaryGI => "Final Gather";
        string ilbSecondaryGI => "Path Tracer";
        float ilbDiffuseBoost => 1;
    }
}
