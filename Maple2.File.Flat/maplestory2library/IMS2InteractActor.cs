using System.Numerics;
using Maple2.File.Flat.standardmodellibrary;

namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2InteractActor : IActor, IMS2InteractObject, I3DProxy, IMS2MapProperties {
        string ModelName => "MS2InteractActor";
        string reactableSequenceName => "0";
        bool IsVisible => true;
        Vector3 Position => default;
        Vector3 Rotation => default;
        float Scale => 1;
        bool MinimapInVisible => true;
        bool Transparency => true;
        bool UseInstancing => false;
    }
}
