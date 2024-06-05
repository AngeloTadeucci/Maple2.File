namespace Maple2.File.Parser.Enum;

public enum NxActorFlag : uint {
    None,
    DisableCollision = 1 << 0,
    DisableResponse = 1 << 1,
    LockCenterOfMass = 1 << 2,
    FluidDisableCollision = 1 << 3,
    ContactModification = 1 << 4,
    ForceConeFriction = 1 << 5,
    UserActorPairFiltering = 1 << 6
}
