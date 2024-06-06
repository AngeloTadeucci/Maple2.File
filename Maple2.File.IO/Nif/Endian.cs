using System.Buffers.Binary;
using System.Numerics;
using System.Text;

namespace Maple2.File.IO.Nif;

public class EndianReader : BinaryReader {
    public bool Swap { get; init; }

    public EndianReader(Stream input, bool swap) : base(input) {
        Swap = swap;
    }

    public ushort ReadAdjustedUInt16() {
        ushort value = ReadUInt16();

        return Swap ? BinaryPrimitives.ReverseEndianness(value) : value;
    }

    public uint ReadAdjustedUInt32() {
        uint value = ReadUInt32();

        return Swap ? BinaryPrimitives.ReverseEndianness(value) : value;
    }

    public int ReadAdjustedInt32() {
        int value = ReadInt32();

        return Swap ? BinaryPrimitives.ReverseEndianness(value) : value;
    }

    public ulong ReadAdjustedUInt64() {
        ulong value = ReadUInt64();

        return Swap ? BinaryPrimitives.ReverseEndianness(value) : value;
    }

    public float ReadAdjustedFloat32() {
        if (!Swap) {
            return ReadSingle();
        }

        byte[] bytes = ReadBytes(4);

        bytes.Reverse();

        return BitConverter.ToSingle(bytes);
    }

    public string ReadAdjustedStringLen32() {
        int length = ReadAdjustedInt32();

        if (length == 0) {
            return string.Empty;
        }

        string? value = Encoding.UTF8.GetString(ReadBytes(length));

        if (value is null) {
            return string.Empty;
        }

        return value;
    }

    // explicitly using 4x4 for matrix multiplication compatibility
    public Matrix4x4 ReadAdjustedMatrix4x3() {
        Matrix4x4 matrix = new Matrix4x4();

        for (int column = 0; column < 3; ++column) {
            for (int row = 0; row < 3; ++row) {
                matrix[row, column] = ReadAdjustedFloat32();
            }
        }

        // Translation
        matrix.M41 = ReadAdjustedFloat32();
        matrix.M42 = ReadAdjustedFloat32();
        matrix.M43 = ReadAdjustedFloat32();
        matrix.M44 = 1;

        return matrix;
    }

    public Vector3 ReadAdjustedVector3() {
        float x = ReadAdjustedFloat32();
        float y = ReadAdjustedFloat32();
        float z = ReadAdjustedFloat32();

        return new Vector3(x, y, z);
    }

    public void Advance(int distance) {
        this.BaseStream.Seek(distance, SeekOrigin.Current);
    }
}
