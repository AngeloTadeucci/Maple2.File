using Maple2.File.IO.Enum;
using System.Numerics;
using System.Text;

namespace Maple2.File.IO.Nif;

public struct PhysXMeshFace {
    public uint Vert0;
    public uint Vert1;
    public uint Vert2;

    public PhysXMeshFace(uint vert0 = 0, uint vert1 = 0, uint vert2 = 0) {
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

        MemoryStream stream = new MemoryStream(data);
        EndianReader reader = new EndianReader(stream, !BitConverter.IsLittleEndian);

        reader.Advance(8);

        switch (headerPiece2) {
            case "CVXM":
                return ParseConvexMesh(reader);
            case "MESH":
                return ParseTriangleMesh(reader);
            case "CLTH":
                throw new NotSupportedException($"Cloth mesh not supported! Found unsupported PhysX cloth mesh in mesh data");
            default:
                throw new InvalidDataException($"Unknown PhysX nxs mesh type {headerPiece2} found in mesh data");
        }
    }

    private NxsMeshType ParseConvexMesh(EndianReader reader) {

        uint unk1 = reader.ReadAdjustedUInt32();
        uint unk2 = reader.ReadAdjustedUInt32();

        byte[] unkDataSection1 = Encoding.UTF8.GetBytes("ICE\x0001CLHL");
        byte[] unkDataSection2 = Encoding.UTF8.GetBytes("ICE\x0001");

        byte[] unkSection1 = reader.ReadBytes(8);

        // Sanity check to check a known piece of data for potential changes
        if (!unkSection1.SequenceEqual(unkDataSection1)) {
            throw new InvalidDataException("Unknown PhysX convex mesh data layout");
        }

        uint unk3 = reader.ReadAdjustedUInt32();

        byte[] unkSection2 = reader.ReadBytes(4);

        // Sanity check to check a known piece of data for potential changes
        if (!unkSection2.SequenceEqual(unkDataSection2)) {
            throw new InvalidDataException("Unknown PhysX convex mesh data layout");
        }

        uint unk4 = reader.ReadAdjustedUInt32();
        uint unk5 = reader.ReadAdjustedUInt32();

        int vertexCount = reader.ReadAdjustedInt32();
        int faceCount = reader.ReadAdjustedInt32();

        uint unk6 = reader.ReadAdjustedUInt32();
        uint unk7 = reader.ReadAdjustedUInt32();
        uint unk8 = reader.ReadAdjustedUInt32();
        uint unk9 = reader.ReadAdjustedUInt32();

        Vertices.EnsureCapacity(vertexCount);
        Faces.EnsureCapacity(faceCount);

        for (int i = 0; i < vertexCount; ++i) {
            Vertices.Add(reader.ReadAdjustedVector3());
        }

        uint unk10 = reader.ReadAdjustedUInt32();

        for (int i = 0; i < faceCount; ++i) {
            PhysXMeshFace face;

            if (vertexCount < 0x100) {
                face = new PhysXMeshFace(
                    reader.ReadByte(),
                    reader.ReadByte(),
                    reader.ReadByte()
                );
            } else if (vertexCount < 0x10000) {
                face = new PhysXMeshFace(
                    reader.ReadUInt16(),
                    reader.ReadUInt16(),
                    reader.ReadUInt16()
                );
            } else {
                face = new PhysXMeshFace(
                    reader.ReadUInt32(),
                    reader.ReadUInt32(),
                    reader.ReadUInt32()
                );
            }

            Faces.Add(face);

            if (face.Vert0 > vertexCount || face.Vert1 > vertexCount || face.Vert2 > vertexCount) {
                throw new IndexOutOfRangeException($"PhysX mesh data may be out of alignment for convex mesh format. Face index found out of bounds [{face.Vert0}, {face.Vert1}, {face.Vert2} with {vertexCount} vertices");
            }
        }

        // There is more data, but none that is mesh relevant as far as I can tell

        return NxsMeshType.Convex;
    }

    private NxsMeshType ParseTriangleMesh(EndianReader reader) {
        uint unk1 = reader.ReadAdjustedUInt32();
        uint unk2 = reader.ReadAdjustedUInt32();
        float unk3 = reader.ReadAdjustedFloat32();
        ulong unk4 = reader.ReadAdjustedUInt64();

        if (unk4 != 0xFF || unk1 != 1) {
            throw new InvalidDataException("Unknown PhysX triangle mesh data format");
        }

        int vertexCount = reader.ReadAdjustedInt32();
        int faceCount = reader.ReadAdjustedInt32();

        Vertices.EnsureCapacity(vertexCount);
        Faces.EnsureCapacity(faceCount);

        for (int i = 0; i < vertexCount; ++i) {
            Vertices.Add(reader.ReadAdjustedVector3());
        }

        for (int i = 0; i < faceCount; ++i) {
            PhysXMeshFace face;

            if (vertexCount < 0x100) {
                face = new PhysXMeshFace(
                    reader.ReadByte(),
                    reader.ReadByte(),
                    reader.ReadByte()
                );
            } else if (vertexCount < 0x10000) {
                face = new PhysXMeshFace(
                    reader.ReadUInt16(),
                    reader.ReadUInt16(),
                    reader.ReadUInt16()
                );
            } else {
                face = new PhysXMeshFace(
                    reader.ReadUInt32(),
                    reader.ReadUInt32(),
                    reader.ReadUInt32()
                );
            }

            Faces.Add(face);

            if (face.Vert0 > vertexCount || face.Vert1 > vertexCount || face.Vert2 > vertexCount) {
                throw new IndexOutOfRangeException($"PhysX mesh data may be out of alignment for triangle mesh format. Face index found out of bounds [{face.Vert0}, {face.Vert1}, {face.Vert2} with {vertexCount} vertices");
            }
        }

        // There is more data, but none that is mesh relevant as far as I can tell

        return NxsMeshType.Triangle;
    }
}
