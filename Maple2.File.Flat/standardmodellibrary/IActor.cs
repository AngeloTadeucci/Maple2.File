using System.Collections.Generic;

namespace Maple2.File.Flat.standardmodellibrary {
    public interface IActor : IRenderable, IShadowable, IBaseEntity, ILightable, IPreloadable, INameable {
        string ModelName => "Actor";
        string KfmAsset => "";
        string InitialSequence => "";
        bool IsKfmAssetShared => true;
        bool IsNifAssetShared => true;
        bool AccumulatesTransforms => false;
        IDictionary<string, string> AttachedObjects => new Dictionary<string, string>();
    }
}
