namespace Maple2.File.Flat.triggerslibrary {
    public interface IRemoteBoolPropertyResponse : IAbstractTriggerResponse {
        string ModelName => "RemoteBoolPropertyResponse";
        string RemoteEntity => "00000000-0000-0000-0000-000000000000";
        string PropertyName => "";
        bool PropertyValue => true;
    }
}
