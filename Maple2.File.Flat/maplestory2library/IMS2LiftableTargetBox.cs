using System.Drawing;
using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2LiftableTargetBox : IWhitebox {
        string ModelName => "MS2LiftableTargetBox";
        int liftableTarget => 0;
        bool isForceFinish => false;
        Vector3 ShapeDimensions => new Vector3(100, 100, 100);
        Color Diffuse => Color.FromArgb(255, 21, 169, 218);
        bool Walkable => false;
        bool RuntimeRender => false;
        bool IsCastingShadow => false;
        bool IsReceivingShadow => false;
        bool IsStatic => true;
    }
}
