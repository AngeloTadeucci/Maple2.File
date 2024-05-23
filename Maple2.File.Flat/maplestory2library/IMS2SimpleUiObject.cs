namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2SimpleUiObject : IMS2PhysXProp, IMS2InteractObject {
        string ModelName => "MS2SimpleUiObject";
        bool MinimapInVisible => false;
    }
}
