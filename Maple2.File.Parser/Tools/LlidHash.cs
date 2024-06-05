namespace Maple2.File.Parser.Tools;

public static class LlidHash {
    public const uint OFFSET_BASIS = 0x811c9dc5;
    public const uint PRIME = 0x01000193;

    // Based on FNV1A32 hash algo
    public static uint Hash(string data) {
        ulong hash = OFFSET_BASIS;

        // Int overflows are required here
        unchecked {
            foreach (byte character in data) {
                hash ^= character;
                hash *= PRIME;
            }
        }

        return (uint) (hash & (ulong) UInt32.MaxValue);
    }
}
