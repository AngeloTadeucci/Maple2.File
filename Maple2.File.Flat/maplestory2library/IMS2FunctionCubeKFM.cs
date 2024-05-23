using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2FunctionCubeKFM : IMS2FunctionCube, IActor, IMS2TextKeyCallback {
        string ModelName => "MS2FunctionCubeKFM";
        bool Inheritance => true;
    }
}
