using System.IO;
using System.Text;

namespace Maple2.File.IO.Nif;

public class NifDocument {
    private readonly byte[] fileData;
    private NifDocumentHeader header;
    public EndianReader Reader { get; private set; }
    public string RelPath { get; init; }
    private NifBlock[] blocks;
    public NifBlock? ReadingBlock { get; private set; }

    public List<NiPhysXProp> PhysXProps { get; init; }
    public string VersionString { get => header.HeaderString; }

    public NifDocument(string relpath, byte[] fileData) {
        PhysXProps = new List<NiPhysXProp>();
        this.fileData = fileData;

        Reader = new EndianReader(new MemoryStream(), false);
        blocks = Array.Empty<NifBlock>();
        header = new NifDocumentHeader();
        RelPath = relpath;
    }

    private int ReadHeaderString() {
        int headerStringLength = Array.IndexOf(fileData, (byte) '\n');

        header.HeaderString = Encoding.UTF8.GetString(fileData, 0, headerStringLength);

        int versionStart = header.HeaderString.LastIndexOf(' ');
        string versionNumbers = header.HeaderString.Substring(versionStart);

        header.Version = Array.ConvertAll(versionNumbers.Split('.'), ushort.Parse);

        return headerStringLength + 1;
    }

    public NifBlock? GetBlock(int index) {
        if (index == -1) {
            return null;
        }

        if (blocks[index] is not null) {
            return blocks[index];
        }

        string blockType = header.BlockTypes[header.BlockTypeIndices[index]];

        NifBlock block = blockType switch {
            "NiPhysXProp" => new NiPhysXProp(index),
            "NiPhysXPropDesc" => new NiPhysXPropDesc(index),
            "NiPhysXActorDesc" => new NiPhysXActorDesc(index),
            "NiPhysXShapeDesc" => new NiPhysXShapeDesc(index),
            "NiPhysXMeshDesc" => new NiPhysXMeshDesc(index),
            _ => new NifBlock(blockType, false, index)
        };

        blocks[index] = block;

        return block;
    }

    public T? GetBlock<T>(int index) {
        if (index == -1) {
            return default;
        }

        NifBlock? block = GetBlock(index);

        if (block is T nifBlock) {
            return nifBlock;
        }

        throw new InvalidCastException($"Invalid block handle <{typeof(T).Name}> referenced block {index}");
    }

    public T? ReadBlockRef<T>() {
        int index = Reader.ReadAdjustedInt32();

        if (index != -1) {
            return GetBlock<T>(index);
        }

        return default;
    }

    public List<T> ReadBlockRefList<T>() {
        List<T> blocks = new List<T>();

        int count = Reader.ReadAdjustedInt32();

        blocks.EnsureCapacity(count);

        for (int i = 0; i < count; ++i) {
            T? block = ReadBlockRef<T>();

            if (block is null) {
                throw new NullReferenceException($"Null/invalid block handle in block list <{typeof(T).Name}> of size {count}");
            }

            blocks.Add(block);
        }

        return blocks;
    }

    public string ReadString() {
        uint stringIndex = Reader.ReadAdjustedUInt32();

        return header.Strings[stringIndex];
    }

    public void Parse() {
        try {
            ParseImplementation();
        } catch (Exception ex) {
            StringBuilder builder = new StringBuilder();

            builder.Append($"Error reading nif: [{RelPath}]");

            if (VersionString.Length > 0) {
                builder.Append($" ({VersionString})");
            }

            if (ReadingBlock is not null) {
                builder.AppendLine($" in block [{ReadingBlock.BlockIndex}] {ReadingBlock.BlockType} \"{ReadingBlock.Name}\"");
            }

            throw new InvalidOperationException(builder.ToString(), ex);
        }
    }

    private void ParseImplementation() {
        int index = ReadHeaderString();

        if (header.Version[0] < 30) {
            throw new NifVersionNotSupportedException($"[{RelPath}]: NIF version number too low: {header.HeaderString}. Parser is built for v30+");
        }

        index += 4;

        bool isLittleEndian = fileData[index] != 0;

        MemoryStream stream = new MemoryStream(fileData);
        Reader = new EndianReader(stream, isLittleEndian != BitConverter.IsLittleEndian);

        Reader.Advance(index + 1);

        uint userVersion = Reader.ReadAdjustedUInt32();
        int numBlocks = Reader.ReadAdjustedInt32();
        int metaBlockSize = Reader.ReadAdjustedInt32();

        Reader.Advance(metaBlockSize);

        ushort numBlockTypes = Reader.ReadAdjustedUInt16();

        if (numBlockTypes == 0) {
            return;
        }

        header.BlockTypes = new string[numBlockTypes];
        header.BlockTypeIndices = new ushort[numBlocks];
        header.BlockSizes = new int[numBlocks];
        blocks = new NifBlock[numBlocks];

        for (uint i = 0; i < numBlockTypes; i++) {
            header.BlockTypes[i] = Reader.ReadAdjustedStringLen32();
        }

        for (uint i = 0; i < numBlocks; i++) {
            // Bit masking here because bit 0x8000 is used to mark engine plugin/extension block types
            header.BlockTypeIndices[i] = (ushort) (0x7FFFU & Reader.ReadAdjustedUInt16());
        }

        for (uint i = 0; i < numBlocks; i++) {
            header.BlockSizes[i] = Reader.ReadAdjustedInt32();
        }

        uint numStrings = Reader.ReadAdjustedUInt32();
        uint maxStringLength = Reader.ReadAdjustedUInt32();

        header.Strings = new string[numStrings];

        for (uint i = 0; i < numStrings; i++) {
            header.Strings[i] = Reader.ReadAdjustedStringLen32();
        }

        uint numGroups = Reader.ReadAdjustedUInt32();

        if (numGroups > 0) {
            throw new NotSupportedException("NIF groups aren't currently supported");
        }

        for (int i = 0; i < numBlocks; ++i) {
            string blockType = header.BlockTypes[header.BlockTypeIndices[i]];
            int blockSize = header.BlockSizes[i];
            long blockStart = Reader.BaseStream.Position;

            NifBlock? block = GetBlock(i);

            if (block is null) {
                throw new InvalidDataException($"Block {i} was null in the block initialization loop with {numBlocks} blocks, where it should never be null");
            }

            ReadingBlock = block;

            block.Parse(this);

            long readBytes = Reader.BaseStream.Position - blockStart;

            if (readBytes != 0 && readBytes != blockSize) {
                throw new TypeLoadException($"Failed to read in the proper block size for type {blockType} index {i}; read {readBytes}, block size: {blockSize}");
            }

            ReadingBlock = null;

            if (readBytes == 0) {
                Reader.Advance(blockSize);
            }
        }
    }
}

