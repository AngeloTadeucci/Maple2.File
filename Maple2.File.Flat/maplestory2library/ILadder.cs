namespace Maple2.File.Flat.maplestory2library {
    public interface ILadder : IMS2PhysXProp {
        string ModelName => "Ladder";
        float ExtrudeOffset => 0;
        bool Climbable => true;
    }
}
