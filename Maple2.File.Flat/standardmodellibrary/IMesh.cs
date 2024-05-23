using System.Collections.Generic;

namespace Maple2.File.Flat.standardmodellibrary {
    public interface IMesh : IRenderable, IBakeable, IShadowable, IBaseEntity, ILightable, IPreloadable {
        string ModelName => "Mesh";
        string NifAsset => "";
        bool IsNifAssetShared => true;
        IDictionary<string, string> AttachedObjects => new Dictionary<string, string>();
    }
}
