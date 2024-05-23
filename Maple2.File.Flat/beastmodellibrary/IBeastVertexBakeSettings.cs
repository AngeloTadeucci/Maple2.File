namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastVertexBakeSettings : IMapEntity {
        string ModelName => "BeastVertexBakeSettings";
        bool ilbVertexFilter => false;
        float ilbVertexFilterSize => 0.01f;
        float ilbVertexFilterNormalDeviation => 6;
    }
}
