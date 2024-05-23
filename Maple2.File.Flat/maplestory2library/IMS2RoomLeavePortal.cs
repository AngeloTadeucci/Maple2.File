namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2RoomLeavePortal : IMS2RoomEnterPortal {
        string ModelName => "MS2RoomLeavePortal";
        int PortalID => 10001;
        uint PortalType => 1;
    }
}
