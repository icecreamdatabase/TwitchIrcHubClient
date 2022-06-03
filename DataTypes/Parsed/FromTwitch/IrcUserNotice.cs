using System.Diagnostics.CodeAnalysis;

namespace TwitchIrcHubClient.DataTypes.Parsed.FromTwitch;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class IrcUserNotice
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
    public string Id { get; init; } = null!;
    public string Login { get; init; } = null!;
    public string? Message { get; init; }
    public UserNoticeMessageId MessageId { get; init; }
    public int RoomId { get; init; }
    public string? SystemMessage { get; init; }
    public DateTime TmiSentTs { get; init; }
    public int UserId { get; init; }

    /* --------------------------------------------------------------------------- */
    /* --------------------- Non-tag but still required data --------------------- */
    /* --------------------------------------------------------------------------- */
    public string RoomName { get; init; } = null!;
    public string? UserInput { get; init; }

    /* --------------------------------------------------------------------------- */
    /* ----------------------------- Conditional tags ---------------------------- */
    /* --------------------------------------------------------------------------- */
    public string? MsgParamCumulativeMonths { get; init; }
    public string? MsgParamDisplayName { get; init; }
    public string? MsgParamLogin { get; init; }
    public string? MsgParamMonths { get; init; }
    public string? MsgParamPromoGiftTotal { get; init; }
    public string? MsgParamPromoName { get; init; }
    public string? MsgParamRecipientDisplayName { get; init; }
    public string? MsgParamRecipientId { get; init; }
    public string? MsgParamRecipientUserName { get; init; }
    public string? MsgParamSenderLogin { get; init; }
    public string? MsgParamSenderName { get; init; }
    public string? MsgParamShouldShareStreak { get; init; }
    public string? MsgParamStreakMonths { get; init; }
    public string? MsgParamSubPlan { get; init; }
    public string? MsgParamSubPlanName { get; init; }
    public string? MsgParamViewerCount { get; init; }
    public UserNoticeRitualName? MsgParamRitualName { get; init; }
    public string? MsgParamThreshold { get; init; }
    public string? MsgParamGiftMonths { get; init; }
    public string? MsgParamMassGiftCount { get; init; }
    public string? MsgParamOriginId { get; init; }
}

public enum UserNoticeMessageId
{
    ParsingError,
    Sub,
    Resub,
    SubGift,
    AnonSubGift,
    SubMysteryGift,
    GiftPaidUpgrade,
    RewardGift,
    AnonGiftPaidUpgrade,
    Raid,
    Unraid,
    Ritual,
    BitsBadgeTier,
    PrimePaidUpgrade,
    Announcement
}

public enum UserNoticeRitualName
{
    ParsingError,
    NewChatter
}
