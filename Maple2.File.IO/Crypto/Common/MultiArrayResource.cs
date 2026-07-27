using System.Resources;

namespace Maple2.File.IO.Crypto.Common {
    public class MultiArrayResource : IMultiArray {
        private readonly ResourceManager resourceManager;
        private readonly string resourceName;
        private readonly Lazy<byte[][]> lazyResource; // TODO: maybe array of lazy (Lazy<byte[]>[])

        string IMultiArray.Name => resourceName;
        public int ArraySize { get; }
        public int Count { get; }

        public byte[] this[uint index] => lazyResource.Value[index % Count];

        public MultiArrayResource(ResourceManager resourceManager, string resourceName, int count, int arraySize) {
            this.resourceManager = resourceManager;
            this.resourceName = resourceName;
            Count = count;
            ArraySize = arraySize;

            lazyResource = new Lazy<byte[][]>(CreateLazyImplementation);
        }

        private byte[][] CreateLazyImplementation() {
            byte[][] result = new byte[Count][];

            byte[] data = (byte[]) resourceManager.GetObject(resourceName);
            using (var reader = new BinaryReader(new MemoryStream(data))) {
                for (int i = 0; i < Count; i++) {
                    byte[] bytes = reader.ReadBytes(ArraySize);
                    if (bytes.Length == ArraySize) {
                        result[i] = bytes;
                    }
                }
            }

            return result;
        }
    }
}
