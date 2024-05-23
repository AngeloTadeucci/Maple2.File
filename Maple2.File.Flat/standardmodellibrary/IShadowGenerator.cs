namespace Maple2.File.Flat.standardmodellibrary {
    public interface IShadowGenerator : IMapEntity {
        string ModelName => "ShadowGenerator";
        bool CastShadows => false;
        bool RenderBackfaces => true;
        string ShadowTechnique => "NiStandardShadowTechnique";
        ushort SizeHint => 512;
        bool StrictlyObserveSizeHint => false;
        bool StaticShadows => false;
        bool UseDefaultDepthBias => true;
        float DepthBias => 0;
    }
}
