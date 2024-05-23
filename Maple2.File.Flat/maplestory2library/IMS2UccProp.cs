namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2UccProp : IMS2Decal, IMS2PhysXProp, IMS2MouseEventable {
        string ModelName => "MS2UccProp";
        int UccID => 0;
        string Index00MeshName => "decal_01";
        bool UseInstancing => false;
        bool LButtonDblClk => true;
        bool Move => true;
    }
}
