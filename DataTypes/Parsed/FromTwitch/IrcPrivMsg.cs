using System.Diagnostics.CodeAnalysis;

namespace TwitchIrcHubClient.DataTypes.Parsed.FromTwitch;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class IrcPrivMsg
{
    public IrcMessage Raw { get; init; } = null!;

    /* --------------------------------------------------------------------------- */
    /* ------------------------------ Required tags ------------------------------ */
    /* --------------------------------------------------------------------------- */
    public Dictionary<string, string> BadgeInfo { get; init; } = null!;
    public Dictionary<string, string> Badges { get; init; } = null!;
    public string Color { get; init; } = null!;
    public string DisplayName { get; init; } = null!;
    public Dictionary<string, string[]> Emotes { get; init; } = null!;
    public bool FirstMsg { get; init; }
    public Dictionary<string, string[]> Flags { get; init; } = null!;
    public string Id { get; init; } = null!;
    public int RoomId { get; init; }
    public DateTime TmiSentTs { get; init; }
    public int UserId { get; init; }
    public bool IsMod { get; init; }
    public bool IsSubscriber { get; init; }
    public bool IsTurbo { get; init; }
    //TODO: UserType enum
    public string? UserType { get; init; }

    /* --------------------------------------------------------------------------- */
    /* --------------------- Non-tag but still required data --------------------- */
    /* --------------------------------------------------------------------------- */
    public string Message { get; init; } = null!;
    public bool IsAction { get; init; }
    public string RoomName { get; init; } = null!;
    public string UserName { get; init; } = null!;

    /* --------------------------------------------------------------------------- */
    /* ----------------------------- Conditional tags ---------------------------- */
    /* --------------------------------------------------------------------------- */
    public string? Bits { get; init; }
    public string? BitsImgUrl { get; init; }
    public string? ClientNonce { get; init; }
    public string? CrowdChantParentMsgId { get; init; }
    public string? CustomRewardId { get; init; }
    public bool? EmoteOnly { get; init; }
    public string? ReplyParentMsgId { get; init; }
    public string? ReplyParentUserId { get; init; }
    public string? ReplyParentUserLogin { get; init; }
    public string? ReplyParentDisplayName { get; init; }
    public string? ReplyParentMsgBody { get; init; }
}
