namespace Maple2.File.Parser.Enum;

public enum NxMeshShapeFlags : uint {
    None = 0,
    SmoothSphereCollisions = 1 << 0,
    DoubleSided = 1 << 1
}
