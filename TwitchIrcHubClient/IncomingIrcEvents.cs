using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.SignalR.Client;
using TwitchIrcHubClient.DataTypes.Parsed.FromTwitch;

namespace TwitchIrcHubClient;

[SuppressMessage("ReSharper", "EventNeverSubscribedTo.Global")]
public class IncomingIrcEvents
{
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

    public IncomingIrcEvents(HubConnection hubConnection)
    {
        hubConnection.On<string>("ConnId", connId => OnConnId?.Invoke(connId));
        hubConnection.On<IrcClearMsg>("NewIrcClearMsg", ircClearMsg => OnNewIrcClearMsg?.Invoke(ircClearMsg));
        hubConnection.On<IrcClearChat>("NewIrcClearChat", ircClearChat => OnNewIrcClearChat?.Invoke(ircClearChat));
        hubConnection.On<IrcGlobalUserState>("NewIrcGlobalUserState", ircGlobalUserState => OnNewIrcGlobalUserState?.Invoke(ircGlobalUserState));
        hubConnection.On<IrcHostTarget>("NewIrcHostTarget", ircHostTarget => OnNewIrcHostTarget?.Invoke(ircHostTarget));
        hubConnection.On<IrcNotice>("NewIrcNotice", ircNotice => OnNewIrcNotice?.Invoke(ircNotice));
        hubConnection.On<IrcPrivMsg>("NewIrcPrivMsg", ircPrivMsg => OnNewIrcPrivMsg?.Invoke(ircPrivMsg));
        hubConnection.On<IrcRoomState>("NewIrcRoomState", ircRoomState => OnNewIrcRoomState?.Invoke(ircRoomState));
        hubConnection.On<IrcUserNotice>("NewIrcUserNotice", ircUserNotice => OnNewIrcUserNotice?.Invoke(ircUserNotice));
        hubConnection.On<IrcUserState>("NewIrcUserState", ircUserState => OnNewIrcUserState?.Invoke(ircUserState));
    }

    protected internal void HubConnectionOnReconnected(string? arg) => OnReconnected?.Invoke(arg);

    protected internal void HubConnectionOnClosed(Exception? exception) => OnClosed?.Invoke(exception);
}
