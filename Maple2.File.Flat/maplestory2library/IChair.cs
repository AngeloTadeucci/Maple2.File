using System.Drawing;
using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IChair : IWhitebox {
        string ModelName => "Chair";
        bool FrontSideOnly => false;
        float Range => 100;
        string StandUpType => "InitialPosition";
        Vector3 ShapeDimensions => new Vector3(100, 50, 20);
        Color Diffuse => Color.FromArgb(255, 255, 155, 0);
        bool RuntimeRender => false;
        bool IsCastingShadow => false;
        bool IsReceivingShadow => false;
    }
}
