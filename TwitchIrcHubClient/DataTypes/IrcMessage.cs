namespace IceCreamDataBaseSignalRTest.DataTypes;

public class IrcMessage
{
    public string RawSource { get; init; } = null!;
    public string IrcPrefixRaw { get; init; } = null!;
    public IrcMessagePrefix IrcPrefix { get; init; } = null!;
    public string IrcCommand { get; init; } = null!;
    public List<string> IrcParameters { get; init; } = null!;
    public Dictionary<string, string> IrcMessageTags { get; init; } = null!;
}
