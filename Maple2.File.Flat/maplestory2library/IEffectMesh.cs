using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IEffectMesh : IMesh, IMS2TimeShowSetting {
        string ModelName => "EffectMesh";
        bool MinimapInVisible => true;
        float ClippingDistance => 3000;
        bool UseInstancing => false;
        bool UseInstancingUpdate => false;
        bool SupportBipedLoop => false;
        int RandomStartDelay => 0;
        bool IsCastingShadow => false;
        bool IsReceivingShadow => false;
        uint MaxDirectionalLights => 0;
        uint MaxPointLights => 0;
        uint MaxSpotLights => 0;
    }
}
