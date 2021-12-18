using System.Diagnostics.CodeAnalysis;

namespace IceCreamDataBaseSignalRTest.DataTypes.Parsed.FromTwitch;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class IrcClearChat
{
    public IrcMessage Raw { get; init; } = null!;

    /* --------------------------------------------------------------------------- */
    /* ------------------------------ Required tags ------------------------------ */
    /* --------------------------------------------------------------------------- */
    public int? BanDuration { get; init; }
    public int RoomId { get; init; }
    public string? TargetUserId { get; init; }
    public DateTime TmiSentTs { get; init; }

    /* --------------------------------------------------------------------------- */
    /* --------------------- Non-tag but still required data --------------------- */
    /* --------------------------------------------------------------------------- */
    public string RoomName { get; init; } = null!;
    public string? TargetUserName { get; init; }
}
