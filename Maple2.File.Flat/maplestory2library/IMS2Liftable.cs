namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2Liftable : IMS2PhysXProp {
        string ModelName => "MS2Liftable";
        uint ItemID => 0;
        int ItemStackCount => 0;
        int ItemLifeTime => 0;
        int LiftableRegenCheckTime => 0;
        int LiftableLifeTime => 0;
        string MaskQuestID => "0";
        string MaskQuestState => "";
        int SpawnPointID => 0;
        int LiftableFinishTime => 0;
        float ActionDistance => 150;
        string EffectQuestID => "0";
        string EffectQuestState => "0";
        bool IsReactEffect => true;
        bool MinimapInVisible => true;
        bool UseInstancing => false;
    }
}
