using Maple2.File.Parser.Enum;
using System.Numerics;
using System.Text;

namespace Maple2.File.Parser.Nif;

public struct PhysXMeshFace {
    public byte Vert0;
    public byte Vert1;
    public byte Vert2;

    public PhysXMeshFace(byte vert0 = 0, byte vert1 = 0, byte vert2 = 0) {
        Vert0 = vert0;
        Vert1 = vert1;
        Vert2 = vert2;
    }
}

public class PhysXMesh {
    public NxsMeshType Type { get; init; }
    public List<Vector3> Vertices { get; init; }
    public List<PhysXMeshFace> Faces { get; init; }

    public PhysXMesh(byte[] data) {
        Vertices = new List<Vector3>();
        Faces = new List<PhysXMeshFace>();

        Type = ParseNxsMesh(data);
    }

    private NxsMeshType ParseNxsMesh(byte[] data) {
        if (data.Length < 8) {
            throw new InvalidDataException("PhysX mesh data too small to fit header");
        }

        string headerPiece1 = Encoding.UTF8.GetString(data, 0, 3);
        string headerPiece2 = Encoding.UTF8.GetString(data, 4, 4);

        if (headerPiece1 != "NXS") {
            throw new InvalidDataException($"Invalid header found in PhysX mesh data: {Encoding.UTF8.GetString(data, 0, 8)}");
        }

        switch (headerPiece2) {
            case "CVXM":
                return ParseConvexMesh(data);
            case "MESH":
                return ParseTriangleMesh(data);
            case "CLTH":
                throw new NotSupportedException($"Cloth mesh not supported! Found unsupported PhysX cloth mesh in mesh data");
            default:
                throw new InvalidDataException($"Unknown PhysX nxs mesh type {headerPiece2} found in mesh data");
        }
    }

    private NxsMeshType ParseConvexMesh(byte[] data) {
        EndianReader reader = new EndianReader(data, !BitConverter.IsLittleEndian, 8);

        uint unk1 = reader.ReadUInt32();
        uint unk2 = reader.ReadUInt32();

        bool unkDataSectionMatches = false;

        unkDataSectionMatches |= data[reader.Index + 0] == 'I';
        unkDataSectionMatches |= data[reader.Index + 0] == 'C';
        unkDataSectionMatches |= data[reader.Index + 0] == 'E';
        unkDataSectionMatches |= data[reader.Index + 0] == 1;
        unkDataSectionMatches |= data[reader.Index + 0] == 'C';
        unkDataSectionMatches |= data[reader.Index + 0] == 'L';
        unkDataSectionMatches |= data[reader.Index + 0] == 'H';
        unkDataSectionMatches |= data[reader.Index + 0] == 'L';

        if (!unkDataSectionMatches) {
            throw new InvalidDataException("Unknown PhysX convex mesh data layout");
        }

        reader.Advance(8);

        uint unk3 = reader.ReadUInt32();

        unkDataSectionMatches = false;

        unkDataSectionMatches |= data[reader.Index + 0] == 'I';
        unkDataSectionMatches |= data[reader.Index + 0] == 'C';
        unkDataSectionMatches |= data[reader.Index + 0] == 'E';
        unkDataSectionMatches |= data[reader.Index + 0] == 1;

        if (!unkDataSectionMatches) {
            throw new InvalidDataException("Unknown PhysX convex mesh data layout");
        }

        reader.Advance(4);

        uint unk4 = reader.ReadUInt32();
        uint unk5 = reader.ReadUInt32();

        int vertexCount = reader.ReadInt32();
        int faceCount = reader.ReadInt32();

        uint unk6 = reader.ReadUInt32();
        uint unk7 = reader.ReadUInt32();
        uint unk8 = reader.ReadUInt32();
        uint unk9 = reader.ReadUInt32();

        Vertices.EnsureCapacity(vertexCount);
        Faces.EnsureCapacity(faceCount);

        for (int i = 0; i < vertexCount; ++i) {
            Vertices.Add(reader.ReadVector3());
        }

        uint unk10 = reader.ReadUInt32();

        for (int i = 0; i < faceCount; ++i) {
            PhysXMeshFace face = new PhysXMeshFace(
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte()
            );

            Faces.Add(face);

            if (face.Vert0 > vertexCount || face.Vert1 > vertexCount || face.Vert2 > vertexCount) {
                throw new IndexOutOfRangeException($"PhysX mesh data may be out of alignment for convex mesh format. Face index found out of bounds [{face.Vert0}, {face.Vert1}, {face.Vert2} with {vertexCount} vertices");
            }
        }

        // There is more data, but none that is mesh relevant as far as I can tell

        return NxsMeshType.Convex;
    }

    private NxsMeshType ParseTriangleMesh(byte[] data) {
        EndianReader reader = new EndianReader(data, !BitConverter.IsLittleEndian, 8);

        uint unk1 = reader.ReadUInt32();
        uint unk2 = reader.ReadUInt32();
        float unk3 = reader.ReadFloat32();
        ulong unk4 = reader.ReadUInt64();

        if (unk4 != 0xFF || unk1 != 1) {
            throw new InvalidDataException("Unknown PhysX triangle mesh data format");
        }

        int vertexCount = reader.ReadInt32();
        int faceCount = reader.ReadInt32();

        Vertices.EnsureCapacity(vertexCount);
        Faces.EnsureCapacity(faceCount);

        for (int i = 0; i < vertexCount; ++i) {
            Vertices.Add(reader.ReadVector3());
        }

        for (int i = 0; i < faceCount; ++i) {
            PhysXMeshFace face = new PhysXMeshFace(
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte()
            );

            Faces.Add(face);

            if (face.Vert0 > vertexCount || face.Vert1 > vertexCount || face.Vert2 > vertexCount) {
                throw new IndexOutOfRangeException($"PhysX mesh data may be out of alignment for triangle mesh format. Face index found out of bounds [{face.Vert0}, {face.Vert1}, {face.Vert2} with {vertexCount} vertices");
            }
        }

        // There is more data, but none that is mesh relevant as far as I can tell

        return NxsMeshType.Triangle;
    }
}
