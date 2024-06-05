using System.Buffers.Binary;
using System.Numerics;
using System.Text;

namespace Maple2.File.IO.Nif;

public class EndianReader {
    public bool Swap { get; init; }
    public byte[] Data { get; init; }
    public int Index { get; private set; }

    public EndianReader(byte[] data, bool swap, int index = 0) {
        Swap = swap;
        Data = data;
        Index = index;
    }

    public bool ReadBool() {
        bool value = BitConverter.ToBoolean(Data, Index);

        Index += 1;

        return value;
    }

    public byte ReadByte() {
        byte value = Data[Index];

        Index += 1;

        return value;
    }

    public ushort ReadUInt16() {
        ushort value = BitConverter.ToUInt16(Data, Index);

        Index += 2;

        if (Swap) {
            return BinaryPrimitives.ReverseEndianness(value);
        }

        return value;
    }

    public uint ReadUInt32() {
        uint value = BitConverter.ToUInt32(Data, Index);

        Index += 4;

        if (Swap) {
            return BinaryPrimitives.ReverseEndianness(value);
        }

        return value;
    }

    public int ReadInt32() {
        int value = BitConverter.ToInt32(Data, Index);

        Index += 4;

        if (Swap) {
            return BinaryPrimitives.ReverseEndianness(value);
        }

        return value;
    }

    public ulong ReadUInt64() {
        ulong value = BitConverter.ToUInt64(Data, Index);

        Index += 8;

        if (Swap) {
            return BinaryPrimitives.ReverseEndianness(value);
        }

        return value;
    }

    public float ReadFloat32() {
        Span<byte> bytes = stackalloc byte[4] { Data[Index + 3], Data[Index + 2], Data[Index + 1], Data[Index] };

        if (Swap) {
            bytes.Reverse();
        }

        Index += 4;

        return BitConverter.ToSingle(bytes);
    }

    public string ReadString(int length) {
        string value = Encoding.UTF8.GetString(Data, Index, length);

        Index += length;

        return value;
    }

    public string ReadStringLen32() {
        int length = ReadInt32();

        if (length == 0) {
            return string.Empty;
        }

        string value = Encoding.UTF8.GetString(Data, Index, length);

        Index += length;

        return value;
    }

    // explicitly using 4x4 for matrix multiplication compatibility
    public Matrix4x4 ReadMatrix4x3() {
        Matrix4x4 matrix = new Matrix4x4();

        for (int column = 0; column < 3; ++column) {
            for (int row = 0; row < 3; ++row) {
                matrix[row, column] = ReadFloat32();
            }
        }

        // Translation
        matrix.M41 = ReadFloat32();
        matrix.M42 = ReadFloat32();
        matrix.M43 = ReadFloat32();
        matrix.M44 = 1;

        return matrix;
    }

    public Vector3 ReadVector3() {
        float x = ReadFloat32();
        float y = ReadFloat32();
        float z = ReadFloat32();

        return new Vector3(x, y, z);
    }

    public void Advance(int distance) {
        Index += distance;
    }
}
