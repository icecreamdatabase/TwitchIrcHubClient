using System.Diagnostics.CodeAnalysis;

namespace TwitchIrcHubClient.DataTypes.Parsed.FromTwitch;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class IrcUserState
{
    public IrcMessage Raw { get; init; } = null!;

    /* --------------------------------------------------------------------------- */
    /* ------------------------------ Required tags ------------------------------ */
    /* --------------------------------------------------------------------------- */
    public Dictionary<string, int> BadgeInfo { get; init; } = null!;
    public Dictionary<string, int> Badges { get; init; } = null!;
    public string Color { get; init; } = null!;
    public string DisplayName { get; init; } = null!;
    public string[] EmoteSets { get; init; } = null!;
    public bool IsMod { get; init; }
    public bool IsSubscriber { get; init; }
    //TODO: UserType enum
    public string? UserType { get; init; }

    /* --------------------------------------------------------------------------- */
    /* --------------------- Non-tag but still required data --------------------- */
    /* --------------------------------------------------------------------------- */
    public string RoomName { get; init; } = null!;
}
