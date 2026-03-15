using System.Globalization;
using System.Text;
using System.Xml;
using Maple2.File.IO.Crypto;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.IO.Crypto.Stream;

namespace Maple2.File.IO {
    public class M2dReader : IDisposable {
        private readonly FileStream m2dFile;
        private readonly object m2dLock = new();
        public readonly IReadOnlyList<PackFileEntry> Files;

        public M2dReader(string path) {
            // Force Globalization to en-US because we use periods instead of commas for decimals
            CultureInfo.CurrentCulture = new("en-US");

            m2dFile = System.IO.File.OpenRead(path);

            // Create an index from the header file
            using var headerReader = new BinaryReader(System.IO.File.OpenRead(path.Replace(".m2d", ".m2h")));
            var stream = IPackStream.CreateStream(headerReader);

            string fileString =
                Encoding.UTF8.GetString(CryptoManager.DecryptFileString(stream, headerReader.BaseStream));
            stream.FileList.AddRange(PackFileEntry.CreateFileList(fileString));
            stream.FileList.Sort();

            // Load the file allocation table and assign each file header to the entry within the list
            byte[] fileTable = CryptoManager.DecryptFileTable(stream, headerReader.BaseStream);

            using var tableStream = new MemoryStream(fileTable);
            using var reader = new BinaryReader(tableStream);
            stream.InitFileList(reader);

            Files = stream.FileList;
        }

        public PackFileEntry GetEntry(string filename) {
            return Files.First(entry => entry.Name.EndsWith(filename));
        }

        public XmlReader GetXmlReader(PackFileEntry entry) {
            return XmlReader.Create(new MemoryStream(CryptoManager.DecryptData(entry.FileHeader, m2dFile, m2dLock)));
        }

        public XmlDocument GetXmlDocument(PackFileEntry entry) {
            var document = new XmlDocument();
            byte[] data = CryptoManager.DecryptData(entry.FileHeader, m2dFile, m2dLock);
            try {
                document.Load(new MemoryStream(data));
            } catch {
                string xmlText = Encoding.Default.GetString(data);
                document.LoadXml(xmlText);
            }

            return document;
        }

        public byte[] GetBytes(PackFileEntry entry) {
            return CryptoManager.DecryptData(entry.FileHeader, m2dFile, m2dLock);
        }

        public string GetString(PackFileEntry entry) {
            byte[] data = CryptoManager.DecryptData(entry.FileHeader, m2dFile, m2dLock);
            string result = Encoding.Default.GetString(data);
            // Remove UTF-8 BOM if present
            if (result.Length > 0 && result[0] == '\uFEFF') {
                return result[1..];
            }
            return result;
        }

        public void Dispose() {
            m2dFile?.Dispose();
        }
    }
}
