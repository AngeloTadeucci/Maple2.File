namespace Maple2.File.IO.Enum;

[Flags]
public enum NxMeshShapeFlags : uint {
    None = 0,
    SmoothSphereCollisions = 1 << 0,
    DoubleSided = 1 << 1
}
