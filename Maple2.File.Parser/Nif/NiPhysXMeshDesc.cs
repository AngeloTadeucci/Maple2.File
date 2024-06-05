using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Nif;

public class NiPhysXMeshDesc : NifBlock {
    public string MeshName;
    public byte[] MeshData;
    public NxMeshShapeFlags MeshFlags = NxMeshShapeFlags.None;
    public NxPagingMode PagingMode = NxPagingMode.Manual;
    public PhysXMeshFlags Flags = PhysXMeshFlags.None;

    public NiPhysXMeshDesc(int blockIndex) : base("NiPhysXMeshDesc", false, blockIndex) { }

    public override void Parse(NifDocument document) {
        base.Parse(document);

        MeshName = document.ReadString();

        int meshSize = document.Reader.ReadInt32();

        MeshData = new byte[meshSize];

        Buffer.BlockCopy(document.Reader.Data, document.Reader.Index, MeshData, 0, meshSize);

        document.Reader.Advance(meshSize);

        MeshFlags = (NxMeshShapeFlags) document.Reader.ReadInt32();
        PagingMode = (NxPagingMode) document.Reader.ReadInt32();
        Flags = (PhysXMeshFlags) document.Reader.ReadByte();
    }
}
