using Maple2.File.IO.Enum;

namespace Maple2.File.IO.Nif;

public class NiPhysXMeshDesc : NifBlock {
    public string MeshName;
    public byte[] MeshData;
    public NxMeshShapeFlags MeshFlags = NxMeshShapeFlags.None;
    public NxPagingMode PagingMode = NxPagingMode.Manual;
    public PhysXMeshFlags Flags = PhysXMeshFlags.None;

    public NiPhysXMeshDesc(int blockIndex) : base("NiPhysXMeshDesc", false, blockIndex) {
        MeshName = string.Empty;
        MeshData = Array.Empty<byte>();
    }

    public override void Parse(NifDocument document) {
        base.Parse(document);

        MeshName = document.ReadString();

        int meshSize = document.Reader.ReadAdjustedInt32();

        MeshData = document.Reader.ReadBytes(meshSize);

        MeshFlags = (NxMeshShapeFlags) document.Reader.ReadAdjustedInt32();
        PagingMode = (NxPagingMode) document.Reader.ReadAdjustedInt32();
        Flags = (PhysXMeshFlags) document.Reader.ReadByte();
    }
}
