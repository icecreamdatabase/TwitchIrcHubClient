using Microsoft.AspNetCore.SignalR.Client;
using TwitchIrcHubClient.DataTypes.Parsed.ToTwitch;

namespace TwitchIrcHubClient;

public class OutgoingIrcEvents
{
    private readonly HubConnection _hubConnection;

    public OutgoingIrcEvents(HubConnection hubConnection)
    {
        _hubConnection = hubConnection;
    }

    public async Task SendPrivMsg(PrivMsgToTwitch privMsgToTwitch)
    {
        await _hubConnection.InvokeAsync("SendPrivMsg", privMsgToTwitch);
    }
}
