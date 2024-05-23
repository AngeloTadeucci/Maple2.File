namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastRenderStats : IMapEntity {
        string ModelName => "BeastRenderStats";
        bool ilbCastGI => true;
        bool ilbReceiveGI => true;
        bool ilbDoubleSided => true;
    }
}
