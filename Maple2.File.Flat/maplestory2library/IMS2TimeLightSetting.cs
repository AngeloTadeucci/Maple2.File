using System.Drawing;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2TimeLightSetting : IMapEntity {
        string ModelName => "MS2TimeLightSetting";
        Color dayDiffuseColor => Color.FromArgb(255, 0, 0, 0);
        Color dayAmbientColor => Color.FromArgb(255, 0, 0, 0);
        float dayDimmer => 0;
        Color nightDiffuseColor => Color.FromArgb(255, 0, 0, 0);
        Color nightAmbientColor => Color.FromArgb(255, 0, 0, 0);
        float nightDimmer => 0;
    }
}
