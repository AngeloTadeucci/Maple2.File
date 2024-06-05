using Maple2.File.IO.Crypto.Common;
using Maple2.File.IO.Nif;
using Maple2.File.Parser.Tools;

namespace Maple2.File.Parser;

public class NifParser {
    private readonly List<NifM2dArchive> modelM2dReaders;

    public NifParser(List<NifM2dArchive> modelM2dReaders) {
        this.modelM2dReaders = modelM2dReaders;
    }

    public IEnumerable<(uint Llid, string relpath, List<NiPhysXProp> PhysXProps)> Parse() {
        foreach (NifM2dArchive nifReader in modelM2dReaders) {
            foreach (PackFileEntry entry in nifReader.M2dReader.Files.Where(entry => entry.Name.EndsWith(".nif"))) {
                string path = nifReader.PathPrefix + entry.Name;
                uint llid = LlidHash.Hash(path);

                NifDocument nifDocument = new NifDocument(path, nifReader.M2dReader.GetBytes(entry));

                try {
                    nifDocument.Parse();
                } catch (Exception ex) {
                    Console.WriteLine("Error reading nif: " + path);

                    if (nifDocument.VersionString.Length > 0) {
                        Console.WriteLine($"\t{nifDocument.VersionString}");
                    }

                    if (nifDocument.ReadingBlock is not null) {
                        Console.WriteLine($"\tin block [{nifDocument.ReadingBlock.BlockIndex}] {nifDocument.ReadingBlock.BlockType} \"{nifDocument.ReadingBlock.Name}\"");
                    }

                    throw;
                }

                yield return (llid, path, nifDocument.PhysXProps);
            }
        }
    }
}
