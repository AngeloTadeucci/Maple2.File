namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2InteractObject : IMapEntity {
        string ModelName => "MS2InteractObject";
        int interactID => 0;
        bool MinimapInVisible => true;
        bool KeepAnimate => false;
    }
}
