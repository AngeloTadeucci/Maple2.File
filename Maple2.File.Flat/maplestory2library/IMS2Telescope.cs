using System.Drawing;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2Telescope : IMS2PhysXProp, IMS2InteractObject {
        string ModelName => "MS2Telescope";
        string CameraIDs => "";
        bool EnableFog => false;
        float FogNear => 0;
        float FogFar => 0;
        Color FogColor => Color.FromArgb(255, 0, 0, 0);
        bool EnableHeightFog => false;
        Color HeightFogColor => Color.FromArgb(255, 0, 0, 0);
        float HeightFogUpperZ => 0;
        float HeightFogLowerZ => 0;
        float HeightFogPercentage => 0;
        string NifAsset => "urn:llid:5c1e3b2a-0000-0000-0000-000000000000";
        bool MinimapInVisible => true;
    }
}
