namespace Maple2.File.Parser.Enum;

public enum NxShapeFlag : uint {
    None,
    Visualization = 1 << 3,
    DisableCollision = 1 << 4,
    FeatureIndices = 1 << 5,
    DisableRaycasting = 1 << 6,
    PointContactForce = 1 << 7,
    FluidDrain = 1 << 8,
    FluidDisableCollision = 1 << 10,
    FluidTwoWay = 1 << 11,
    DisableResponse = 1 << 12,
    DynamicDynamicCCD = 1 << 13,
    DisableSceneQueries = 1 << 14,
    ClothDrain = 1 << 15,
    ClothDisableCollision = 1 << 16,
    ClothTwoWay = 1 << 17,
    SoftBodyDrain = 1 << 18,
    SoftBodyDisableCollision = 1 << 19,
    SoftBodyTwoWay = 1 << 20
}

