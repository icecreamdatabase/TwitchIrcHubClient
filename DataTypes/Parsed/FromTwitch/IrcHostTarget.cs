using System.Diagnostics.CodeAnalysis;

namespace TwitchIrcHubClient.DataTypes.Parsed.FromTwitch;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class IrcHostTarget
{
    public IrcMessage Raw { get; init; } = null!;

    /* --------------------------------------------------------------------------- */
    /* --------------------- Non-tag but still required data --------------------- */
    /* --------------------------------------------------------------------------- */
    public string? HostReceiverRoomName { get; init; } = null;
    public string RoomName { get; init; } = null!;
    public int? NumberOfViews { get; init; } = null;
}
