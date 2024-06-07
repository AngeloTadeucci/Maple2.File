namespace Maple2.File.Parser.Nif;

public class NifBlock {
    public string BlockType { get; init; }
    public bool HasName { get; init; }
    public int BlockIndex { get; init; }
    public string Name;

    public NifBlock(string blockType, bool hasName, int blockIndex) {
        BlockType = blockType;
        HasName = hasName;
        BlockIndex = blockIndex;
        Name = string.Empty;
    }

    public virtual void Parse(NifDocument document) {
        if (HasName) {
            Name = document.ReadString();
        }

        document.Reading(this);
    }
}
