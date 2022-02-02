using System.Diagnostics.CodeAnalysis;

namespace TwitchIrcHubClient.DataTypes.Parsed.FromTwitch;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class IrcRoomState
{
    public IrcMessage Raw { get; init; } = null!;

    /* --------------------------------------------------------------------------- */
    /* ------------------------------ Required tags ------------------------------ */
    /* --------------------------------------------------------------------------- */
    public bool EmoteOnly { get; init; }
    public int FollowersOnly { get; init; }
    public bool R9K { get; init; }
    public bool Rituals { get; init; }
    public int RoomId { get; init; }
    public int Slow { get; init; }
    public bool SubsOnly { get; init; }

    /* --------------------------------------------------------------------------- */
    /* --------------------- Non-tag but still required data --------------------- */
    /* --------------------------------------------------------------------------- */
    public string RoomName { get; init; } = null!;
}
