namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2TriggerPortal : IPortal, IMS2TriggerObject {
        string ModelName => "MS2TriggerPortal";
        int DivideTriggerBoxID => 0;
        int DivideUserCount => 0;
        int DividePortalID => 0;
        string NifAsset => "urn:llid:dcc516bf-0000-0000-0000-000000000000";
        float Scale => 0.7f;
    }
}
