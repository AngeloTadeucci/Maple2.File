using Maple2.File.IO;

namespace Maple2.File.Parser.Nif;

public class NifM2dArchive {
    public string PathPrefix { get; init; }
    public M2dReader M2dReader { get; init; }

    public NifM2dArchive(string pathPrefix, M2dReader m2dReader) {
        PathPrefix = pathPrefix;
        M2dReader = m2dReader;
    }
}
