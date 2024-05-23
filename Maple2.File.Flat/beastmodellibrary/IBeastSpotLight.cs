using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.beastmodellibrary {
    public interface IBeastSpotLight : IPCLSpotLight, IBeastPointLight {
        string ModelName => "BeastSpotLight";
        float ConstantAttenuation => 1;
        float LinearAttenuation => 0;
        float QuadraticAttenuation => 0;
        float AttenuationVisualizerThreshold => 0.05f;
        Vector3 AttenuationVisualizerOrientation => default;
        Color AmbientColor => Color.FromArgb(255, 0, 0, 0);
        Color DiffuseColor => Color.FromArgb(255, 255, 255, 255);
        Color SpecularColor => Color.FromArgb(255, 255, 255, 255);
        float Dimmer => 1;
        float Range => 10000;
        Vector3 RangeVisualizerOrientation => default;
        float LightPriority => 50;
        bool UpdateLightingOnMove => false;
        IDictionary<string, string> AlwaysAffectedByLight => new Dictionary<string, string>();
        IDictionary<string, string> NeverAffectedByLight => new Dictionary<string, string>();
        string ProxyNifAsset => "urn:llid:83383ddc-0000-0000-0000-000000000000";
        float ProxyScale => 0.01f;
        bool IsVisible => true;
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
        bool IsStatic => true;
        bool CastShadows => true;
        bool RenderBackfaces => true;
        string ShadowTechnique => "NiStandardShadowTechnique";
        ushort SizeHint => 512;
        bool StrictlyObserveSizeHint => false;
        bool StaticShadows => false;
        bool UseDefaultDepthBias => true;
        float DepthBias => 0;
        bool LightPCLObjectsAtRuntime => false;
        bool LightNonPCLObjectsAtRuntime => true;
        bool UseForPrecomputedLighting => true;
    }
}
