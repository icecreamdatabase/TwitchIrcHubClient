namespace IceCreamDataBaseSignalRTest.DataTypes;

public class IrcMessagePrefix
{
    public string? Nickname { get; init; } = null;
    public string? Username { get; init; } = null;
    public string Hostname { get; init; } = null!;
}