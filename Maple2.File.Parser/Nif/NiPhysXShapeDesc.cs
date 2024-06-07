using Maple2.File.Parser.Enum;
using System.Numerics;

namespace Maple2.File.Parser.Nif;

public class NiPhysXShapeDesc : NifBlock {
    public NxShapeType ShapeType = NxShapeType.Plane;
    public NxShapeFlag Flags = NxShapeFlag.Visualization | NxShapeFlag.ClothTwoWay | NxShapeFlag.SoftBodyTwoWay;
    public Matrix4x4 LocalPose;
    public ushort CollisionGroup;
    public ushort MaterialIndex;
    public float Density = 1;
    public float Mass = 1;
    public float SkinWidth = 0.01f;
    public string ShapeName;
    public uint NonInteractingCompartment;
    public uint[] CollisionBits;
    public NiPhysXMeshDesc? Mesh;
    public Vector3 BoxHalfExtents;

    public NiPhysXShapeDesc(int blockIndex) : base("NiPhysXShapeDesc", false, blockIndex) {
        CollisionBits = new uint[4];
    }

    public override void Parse(NifDocument document) {
        base.Parse(document);

        ShapeType = (NxShapeType) document.Reader.ReadUInt32();
        Flags = (NxShapeFlag) document.Reader.ReadUInt32();
        LocalPose = document.Reader.ReadMatrix4x3();
        CollisionGroup = document.Reader.ReadUInt16();
        MaterialIndex = document.Reader.ReadUInt16();
        Density = document.Reader.ReadFloat32();
        Mass = document.Reader.ReadFloat32();
        SkinWidth = document.Reader.ReadFloat32();
        ShapeName = document.ReadString();
        NonInteractingCompartment = document.Reader.ReadUInt32();

        for (int i = 0; i < 4; ++i) {
            CollisionBits[i] = document.Reader.ReadUInt32();
        }

        switch (ShapeType) {
            case NxShapeType.Box:
                BoxHalfExtents = document.Reader.ReadVector3();
                break;
            case NxShapeType.Mesh:
            case NxShapeType.Convex:
                Mesh = document.ReadBlockRef<NiPhysXMeshDesc>();
                break;
            default:
                throw new NotSupportedException($"Unsupported NiPhysXShapeDesc.ShapeType found: {ShapeType}");
        }
    }
}

