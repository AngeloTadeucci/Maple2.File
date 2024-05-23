namespace Maple2.File.Flat.standardmodellibrary {
    public interface IRenderable : IPlaceable {
        string ModelName => "Renderable";
        bool IsVisible => true;
    }
}
