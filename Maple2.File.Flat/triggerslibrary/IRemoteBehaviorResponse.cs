namespace Maple2.File.Flat.triggerslibrary {
    public interface IRemoteBehaviorResponse : IAbstractTriggerResponse {
        string ModelName => "RemoteBehaviorResponse";
        string RemoteEntity => "00000000-0000-0000-0000-000000000000";
        string BehaviorName => "";
    }
}
