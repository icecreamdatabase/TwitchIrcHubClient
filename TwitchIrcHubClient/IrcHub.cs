using IceCreamDataBaseSignalRTest.DataTypes.Parsed.FromTwitch;
using Microsoft.AspNetCore.SignalR.Client;

namespace TwitchIrcHubClient;

public class IrcHub
{
    private readonly HubConnection _hubConnection;
    
    public delegate void Reconnected(string? arg);

    public event Reconnected? OnReconnected;
    
    public delegate void Closed(Exception? exception);

    public event Closed? OnClosed;

    public delegate void ConnId(string connId);

    public event ConnId? OnConnId;

    public delegate void NewIrcClearMsg(IrcClearMsg ircClearMsg);

    public event NewIrcClearMsg? OnNewIrcClearMsg;

    public delegate void NewIrcClearChat(IrcClearChat ircClearChat);

    public event NewIrcClearChat? OnNewIrcClearChat;

    public delegate void NewIrcGlobalUserState(IrcGlobalUserState ircGlobalUserState);

    public event NewIrcGlobalUserState? OnNewIrcGlobalUserState;

    public delegate void NewIrcHostTarget(IrcHostTarget ircHostTarget);

    public event NewIrcHostTarget? OnNewIrcHostTarget;

    public delegate void NewIrcNotice(IrcNotice ircNotice);

    public event NewIrcNotice? OnNewIrcNotice;

    public delegate void NewIrcPrivMsg(IrcPrivMsg ircPrivMsg);

    public event NewIrcPrivMsg? OnNewIrcPrivMsg;

    public delegate void NewIrcRoomState(IrcRoomState ircRoomState);

    public event NewIrcRoomState? OnNewIrcRoomState;

    public delegate void NewIrcUserNotice(IrcUserNotice ircUserNotice);

    public event NewIrcUserNotice? OnNewIrcUserNotice;

    public delegate void NewIrcUserState(IrcUserState ircUserState);

    public event NewIrcUserState? OnNewIrcUserState;

    public IrcHub(string appIdKey)
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl($"https://botapitest.icdb.dev/IrcHub?appIdKey={appIdKey}")
            .WithAutomaticReconnect(new EndlessRetryPolicy())
            .Build();

        _hubConnection.Reconnected += HubConnectionOnReconnected;
        _hubConnection.Closed += HubConnectionOnClosed;
        _hubConnection.On<string>("ConnId", connId => OnConnId?.Invoke(connId));
        _hubConnection.On<IrcClearMsg>("NewIrcClearMsg", ircClearMsg => OnNewIrcClearMsg?.Invoke(ircClearMsg));
        _hubConnection.On<IrcClearChat>("NewIrcClearChat", ircClearChat => OnNewIrcClearChat?.Invoke(ircClearChat));
        _hubConnection.On<IrcGlobalUserState>("NewIrcGlobalUserState", ircGlobalUserState => OnNewIrcGlobalUserState?.Invoke(ircGlobalUserState));
        _hubConnection.On<IrcHostTarget>("NewIrcHostTarget", ircHostTarget => OnNewIrcHostTarget?.Invoke(ircHostTarget));
        _hubConnection.On<IrcNotice>("NewIrcNotice", ircNotice => OnNewIrcNotice?.Invoke(ircNotice));
        _hubConnection.On<IrcPrivMsg>("NewIrcPrivMsg", ircPrivMsg => OnNewIrcPrivMsg?.Invoke(ircPrivMsg));
        _hubConnection.On<IrcRoomState>("NewIrcRoomState", ircRoomState => OnNewIrcRoomState?.Invoke(ircRoomState));
        _hubConnection.On<IrcUserNotice>("NewIrcUserNotice", ircUserNotice => OnNewIrcUserNotice?.Invoke(ircUserNotice));
        _hubConnection.On<IrcUserState>("NewIrcUserState", ircUserState => OnNewIrcUserState?.Invoke(ircUserState));

        _hubConnection.StartAsync();
    }
    
    private async Task HubConnectionOnReconnected(string? arg)
    {
        Console.WriteLine($"Reconnected: {arg}");
        OnReconnected?.Invoke(arg);
    }

    private async Task HubConnectionOnClosed(Exception? exception)
    {
        Console.WriteLine($"Closed: {exception}");
        OnClosed?.Invoke(exception);
    }
}

internal class EndlessRetryPolicy : IRetryPolicy
{
    private readonly Random _random = new();

    public TimeSpan? NextRetryDelay(RetryContext retryContext)
    {
        double seconds = _random.NextDouble() * 10;
        Console.WriteLine($"Retrying in {Math.Round(seconds * 100) / 100} s.");
        return TimeSpan.FromSeconds(seconds);
    }
}
