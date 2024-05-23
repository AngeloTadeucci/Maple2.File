using System.Drawing;
using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2TriggerBox : IWhitebox, IMS2TriggerObject {
        string ModelName => "MS2TriggerBox";
        Vector3 ShapeDimensions => new Vector3(100, 100, 100);
        Color Diffuse => Color.FromArgb(255, 252, 156, 52);
        bool Walkable => false;
        bool RuntimeRender => false;
        bool IsCastingShadow => false;
        bool IsReceivingShadow => false;
        bool IsStatic => true;
    }
}
