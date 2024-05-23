using System.Numerics;

namespace Maple2.File.Flat.maplestory2library {
    public interface IPortal : IEffectMesh {
        string ModelName => "Portal";
        int TargetFieldSN => 0;
        int TargetPortalID => 0;
        int PortalID => 0;
        uint PortalType => 0;
        int ActionType => 0;
        bool PortalEnable => true;
        Vector3 PortalDimension => new Vector3(200, 200, 250);
        Vector3 PortalOffset => new Vector3(0, 0, 100);
        string MaskQuestID => "0";
        string MaskQuestState => "0";
        bool MinimapIconVisible => false;
        string QuestPortalAssetName => "";
        float frontOffset => 0;
        bool IsHomePrivilege => false;
        int RandomDestRadius => 0;
        string feature => "";
        string locale => "";
    }
}
