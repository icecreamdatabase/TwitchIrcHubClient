using System.Diagnostics.CodeAnalysis;

namespace IceCreamDataBaseSignalRTest.DataTypes.Parsed.FromTwitch;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class IrcClearMsg
{
    public IrcMessage Raw { get; init; } = null!;

    /* --------------------------------------------------------------------------- */
    /* ------------------------------ Required tags ------------------------------ */
    /* --------------------------------------------------------------------------- */
    public string Login { get; init; } = null!;
    public int RoomId { get; init; }
    public string TargetMsgId { get; init; } = null!;
    public DateTime TmiSentTs { get; init; }

    /* --------------------------------------------------------------------------- */
    /* --------------------- Non-tag but still required data --------------------- */
    /* --------------------------------------------------------------------------- */
    public string Message { get; init; } = null!;
    public string RoomName { get; init; } = null!;
}
