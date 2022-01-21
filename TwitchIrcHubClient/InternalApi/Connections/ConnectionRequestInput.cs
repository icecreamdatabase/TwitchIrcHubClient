using System.Diagnostics.CodeAnalysis;

namespace TwitchIrcHubClient.InternalApi.Connections;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
internal class ConnectionRequestInput
{
    public int BotUserId { get; init; }
    public List<int> RoomIds { get; init; } = new();
}
