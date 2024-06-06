using Maple2.File.IO.Crypto.Common;
using Maple2.File.IO.Nif;
using Maple2.File.Parser.Tools;
using System.Text;

namespace Maple2.File.Parser;

public class NifParser {
    private readonly List<PrefixedM2dReader> modelM2dReaders;

    public NifParser(List<PrefixedM2dReader> modelM2dReaders) {
        this.modelM2dReaders = modelM2dReaders;
    }

    public IEnumerable<(uint llid, string relpath, NifDocument document)> Parse() {
        foreach (PrefixedM2dReader nifReader in modelM2dReaders) {
            foreach (PackFileEntry entry in nifReader.Files.Where(entry => entry.Name.EndsWith(".nif"))) {
                string path = nifReader.PathPrefix + entry.Name;
                uint llid = LlidHash.Hash(path);

                NifDocument nifDocument = new NifDocument(path, nifReader.GetBytes(entry));

                yield return (llid, path, nifDocument);
            }
        }
    }
}
