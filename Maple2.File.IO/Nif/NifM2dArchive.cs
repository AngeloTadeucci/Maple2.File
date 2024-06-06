namespace Maple2.File.IO.Nif;

public class PrefixedM2dReader : M2dReader {
    public string PathPrefix { get; init; }

    public PrefixedM2dReader(string pathPrefix, string path) : base(path) {
        PathPrefix = pathPrefix;
    }
}
