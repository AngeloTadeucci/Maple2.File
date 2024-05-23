using System.Drawing;

namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastEnvironmentSettings : IMapEntity {
        string ModelName => "BeastEnvironmentSettings";
        string ilbEnvironment => "None";
        string ilbHDRFile => "";
        float ilbHDRBlur => 0;
        float ilbHDRRotation => 0;
        Color ilbEnvironmentColor => Color.FromArgb(255, 97, 188, 211);
        float ilbHDRIntensity => 1;
    }
}
