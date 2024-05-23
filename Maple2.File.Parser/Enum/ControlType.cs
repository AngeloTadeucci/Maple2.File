namespace Maple2.File.Parser.Enum;

public enum ControlType {
    None = 0,
    Default = 1, // Seems this is the default value instead of None
    Sensor = 2,
    SpawnNPC = 4,
    Skill = 5,
    Portal = 6,
    Breeding = 7,
    Farming = 8,
    PVP = 9,
    SpawnPoint = 10,
    InstallNPC = 11,
    Notice = 12,
    Nurturing = 13,

    // Not sure which values these are, all map to 3?
    Switch,
    FunctionUI,
    Ride,
    OpenWeb,
}
