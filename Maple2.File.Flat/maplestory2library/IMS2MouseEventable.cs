namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2MouseEventable : IMapEntity {
        string ModelName => "MS2MouseEventable";
        bool LButtonDown => false;
        bool LButtonDblClk => false;
        bool LButtonUp => false;
        bool RButtonDown => false;
        bool RButtonDblClk => false;
        bool RButtonUp => false;
        bool Move => false;
    }
}
