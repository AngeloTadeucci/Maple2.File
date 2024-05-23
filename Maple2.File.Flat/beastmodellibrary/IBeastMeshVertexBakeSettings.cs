namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastMeshVertexBakeSettings : IMapEntity {
        string ModelName => "BeastMeshVertexBakeSettings";
        ushort ilbMinVertexSampleRate => 0;
        ushort ilbMaxVertexSampleRate => 0;
    }
}
