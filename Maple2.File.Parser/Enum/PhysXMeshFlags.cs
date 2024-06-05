namespace Maple2.File.Parser.Enum;

public enum PhysXMeshFlags : byte {
    None = 0,
    IsConvex = 0x1,
    IsCloth = 0x2,
    Hardware = 0x4,
    CookedForWin32 = 0x8,
    CookedForPS3 = 0x10,
    CookedForXenon = 0x20
}
