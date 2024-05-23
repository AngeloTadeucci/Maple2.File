using System.Drawing;
using System.Numerics;
using Maple2.File.Flat.physxmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2TriggerBlock : IPhysXWhitebox, IMS2TriggerObject {
        string ModelName => "MS2TriggerBlock";
        Vector3 ShapeDimensions => new Vector3(100, 100, 100);
        Color Diffuse => Color.FromArgb(255, 53, 55, 188);
        bool RuntimeRender => false;
        bool IsCastingShadow => false;
        bool IsReceivingShadow => false;
        bool IsStatic => true;
    }
}
