namespace Maple2.File.Flat.maplestory2library {
    public interface IMS2TriggerActorCube : IMS2TriggerActor, IMS2MapProperties {
        string ModelName => "MS2TriggerActorCube";
        int ActorCubeType => 0;
        bool SwitchOnOff => false;
        string SequenceName => "";
        int AdditionalFunc => 0;
        bool Operable => true;
        bool MinimapInVisible => true;
    }
}
