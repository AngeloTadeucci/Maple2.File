using System.Text;

namespace Maple2.File.IO.Nif;

public class NifDocument {
    private readonly byte[] fileData;
    private NifDocumentHeader header;
    public EndianReader Reader { get; private set; }
    public string RelPath { get; init; }
    private NifBlock?[] blocks;
    public NifBlock? ReadingBlock { get; private set; }

    public List<NiPhysXProp> PhysXProps { get; init; }
    public string VersionString { get => header.HeaderString; }

    public NifDocument(string relpath, byte[] fileData) {
        PhysXProps = new List<NiPhysXProp>();
        this.fileData = fileData;
        Reader = new EndianReader(Array.Empty<byte>(), false);
        blocks = Array.Empty<NifBlock?>();
        header = new NifDocumentHeader();
        RelPath = relpath;
    }

    private int ReadHeaderString() {
        int index = 0;
        int headerStringLength = 0;

        while (headerStringLength < fileData.Length && fileData[headerStringLength] != 0x0A) {
            headerStringLength++;
        }

        header.HeaderString = Encoding.UTF8.GetString(fileData, 0, headerStringLength);

        index += headerStringLength + 1;

        int versionStart = headerStringLength;

        while (versionStart - 1 > 0 && (fileData[versionStart - 1] == '.' || (fileData[versionStart - 1] >= '0' && fileData[versionStart - 1] <= '9'))) {
            --versionStart;
        }

        for (int i = 0; i < 4; ++i) {
            int versionEnd = versionStart;

            while (versionEnd < headerStringLength && fileData[versionEnd] != '.')
                ++versionEnd;

            string versionText = Encoding.UTF8.GetString(fileData, versionStart, versionEnd - versionStart);

            header.Version[i] = ushort.Parse(versionText);

            versionStart = versionEnd + 1;
        }

        return index;
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
        int index = Reader.ReadInt32();

        if (index != -1) {
            return GetBlock<T>(index);
        }

        return default;
    }

    public List<T> ReadBlockRefList<T>() {
        List<T> blocks = new List<T>();

        int count = Reader.ReadInt32();

        blocks.EnsureCapacity(count);

        for (int i = 0; i < count; ++i) {
            T? block = ReadBlockRef<T>();

            if (block is null) {
                throw new InvalidCastException($"Null/invalid block handle in block list <{typeof(T).Name}> of size {count}");
            }

            blocks.Add(block);
        }

        return blocks;
    }

    public string ReadString() {
        uint stringIndex = Reader.ReadUInt32();

        return header.Strings[stringIndex];
    }

    public void Reading(NifBlock block) {
        ReadingBlock = block;
    }

    public bool Parse() {
        int index = ReadHeaderString();

        if (header.Version[0] < 30) {
            Console.WriteLine(RelPath);
            Console.WriteLine($"NIF version number too low: {header.HeaderString}. Parser is built for v30+"); // is it possible to do warnings?

            return false;
        }

        index += 4;

        bool isLittleEndian = fileData[index] != 0;

        Reader = new EndianReader(fileData, isLittleEndian != BitConverter.IsLittleEndian, index + 1);

        uint userVersion = Reader.ReadUInt32();
        int numBlocks = Reader.ReadInt32();
        int metaBlockSize = Reader.ReadInt32();

        Reader.Advance(metaBlockSize);

        ushort numBlockTypes = Reader.ReadUInt16();

        if (numBlockTypes == 0) {
            return true;
        }

        header.BlockTypes = new string[numBlockTypes];
        header.BlockTypeIndices = new ushort[numBlocks];
        header.BlockSizes = new int[numBlocks];
        blocks = new NifBlock?[numBlocks];

        for (uint i = 0; i < numBlockTypes; i++) {
            header.BlockTypes[i] = Reader.ReadStringLen32();
        }

        for (uint i = 0; i < numBlocks; i++) {
            header.BlockTypeIndices[i] = (ushort) (0x7FFFU & Reader.ReadUInt16());
        }

        for (uint i = 0; i < numBlocks; i++) {
            header.BlockSizes[i] = Reader.ReadInt32();
        }

        uint numStrings = Reader.ReadUInt32();
        uint maxStringLength = Reader.ReadUInt32();

        header.Strings = new string[numStrings];

        for (uint i = 0; i < numStrings; i++) {
            header.Strings[i] = Reader.ReadStringLen32();
        }

        uint numGroups = Reader.ReadUInt32();

        if (numGroups > 0) {
            throw new NotSupportedException("NIF groups aren't currently supported");
        }

        for (int i = 0; i < numBlocks; ++i) {
            string blockType = header.BlockTypes[header.BlockTypeIndices[i]];
            int blockSize = header.BlockSizes[i];

            int blockStart = Reader.Index;


            NifBlock? block = GetBlock(i);

            block?.Parse(this);

            int readBytes = Reader.Index - blockStart;

            if (readBytes != 0 && readBytes != blockSize) {
                throw new TypeLoadException($"Failed to read in the proper block size for type {blockType} index {i}; read {readBytes}, block size: {blockSize}");
            }

            ReadingBlock = null;

            if (readBytes == 0) {
                Reader.Advance(blockSize);
            }
        }

        return true;
    }
}

