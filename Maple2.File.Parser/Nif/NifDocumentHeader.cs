namespace Maple2.File.Parser.Nif;

public struct NifDocumentHeader {
    public string HeaderString;
    public ushort[] Version;
    public string[] BlockTypes;
    public ushort[] BlockTypeIndices;
    public int[] BlockSizes;
    public string[] Strings;

    public NifDocumentHeader() {
        HeaderString = string.Empty;
        Version = new ushort[4];
        BlockTypes = Array.Empty<string>();
        BlockTypeIndices = Array.Empty<ushort>();
        BlockSizes = Array.Empty<int>();
        Strings = Array.Empty<string>();
    }
}
