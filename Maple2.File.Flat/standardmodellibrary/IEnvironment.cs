using System.Drawing;

namespace Maple2.File.Flat.standardmodellibrary {
    public interface IEnvironment : ITimeOfDayEditable {
        string ModelName => "Environment";
        string EnvironmentSunEntity => "00000000-0000-0000-0000-000000000000";
        bool EnvironmentAutoFogColor => true;
        bool EnvironmentUseSunAnlges => true;
        Color EnvironmentFogColor => Color.FromArgb(255, 7, 161, 252);
        float EnvironmentSunAzimuthAngle => 0;
        float EnvironmentSunElevationAngle => 30;
        float EnvironmentSunSize => 1;
        float EnvironmentSunIntensity => 15;
        float EnvironmentPhaseConstant => -0.99f;
        float EnvironmentRayleighConstant => 0.0025f;
        float EnvironmentMieConstant => 0.0015f;
        float EnvironmentHDRExposure => 2;
        float EnvironmentRedWavelength => 0.65f;
        float EnvironmentGreenWavelength => 0.57f;
        float EnvironmentBlueWavelength => 0.475f;
        float EnvironmentDomeRadius => 1000;
        float EnvironmentDomeDetail => 8;
        float EnvironmentDomeDetailAxisBias => 0.6f;
        float EnvironmentDomeDetailHorizontalBias => 0.9f;
    }
}
