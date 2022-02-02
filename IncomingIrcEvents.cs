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

    public delegate void NewIrcClearMsg(int botUserId, IrcClearMsg ircClearMsg);

    public event NewIrcClearMsg? OnNewIrcClearMsg;

    public delegate void NewIrcClearChat(int botUserId, IrcClearChat ircClearChat);

    public event NewIrcClearChat? OnNewIrcClearChat;

    public delegate void NewIrcGlobalUserState(int botUserId, IrcGlobalUserState ircGlobalUserState);

    public event NewIrcGlobalUserState? OnNewIrcGlobalUserState;

    public delegate void NewIrcHostTarget(int botUserId, IrcHostTarget ircHostTarget);

    public event NewIrcHostTarget? OnNewIrcHostTarget;

    public delegate void NewIrcNotice(int botUserId, IrcNotice ircNotice);

    public event NewIrcNotice? OnNewIrcNotice;

    public delegate void NewIrcPrivMsg(int botUserId, IrcPrivMsg ircPrivMsg);

    public event NewIrcPrivMsg? OnNewIrcPrivMsg;

    public delegate void NewIrcRoomState(int botUserId, IrcRoomState ircRoomState);

    public event NewIrcRoomState? OnNewIrcRoomState;

    public delegate void NewIrcUserNotice(int botUserId, IrcUserNotice ircUserNotice);

    public event NewIrcUserNotice? OnNewIrcUserNotice;

    public delegate void NewIrcUserState(int botUserId, IrcUserState ircUserState);

    public event NewIrcUserState? OnNewIrcUserState;

    public IncomingIrcEvents(HubConnection hubConnection)
    {
        hubConnection.On<string>(
            "ConnId",
            connId => OnConnId?.Invoke(connId)
        );
        hubConnection.On<int, IrcClearMsg>(
            "NewIrcClearMsg",
            (botUserId, ircClearMsg) => OnNewIrcClearMsg?.Invoke(botUserId, ircClearMsg)
        );
        hubConnection.On<int, IrcClearChat>(
            "NewIrcClearChat",
            (botUserId, ircClearChat) => OnNewIrcClearChat?.Invoke(botUserId, ircClearChat)
        );
        hubConnection.On<int, IrcGlobalUserState>(
            "NewIrcGlobalUserState",
            (botUserId, ircGlobalUserState) => OnNewIrcGlobalUserState?.Invoke(botUserId, ircGlobalUserState)
        );
        hubConnection.On<int, IrcHostTarget>(
            "NewIrcHostTarget",
            (botUserId, ircHostTarget) => OnNewIrcHostTarget?.Invoke(botUserId, ircHostTarget)
        );
        hubConnection.On<int, IrcNotice>(
            "NewIrcNotice",
            (botUserId, ircNotice) => OnNewIrcNotice?.Invoke(botUserId, ircNotice)
        );
        hubConnection.On<int, IrcPrivMsg>(
            "NewIrcPrivMsg",
            (botUserId, ircPrivMsg) => OnNewIrcPrivMsg?.Invoke(botUserId, ircPrivMsg)
        );
        hubConnection.On<int, IrcRoomState>(
            "NewIrcRoomState",
            (botUserId, ircRoomState) => OnNewIrcRoomState?.Invoke(botUserId, ircRoomState)
        );
        hubConnection.On<int, IrcUserNotice>(
            "NewIrcUserNotice",
            (botUserId, ircUserNotice) => OnNewIrcUserNotice?.Invoke(botUserId, ircUserNotice)
        );
        hubConnection.On<int, IrcUserState>(
            "NewIrcUserState",
            (botUserId, ircUserState) => OnNewIrcUserState?.Invoke(botUserId, ircUserState)
        );
    }

    protected internal void HubConnectionOnReconnected(string? arg) => OnReconnected?.Invoke(arg);

    protected internal void HubConnectionOnClosed(Exception? exception) => OnClosed?.Invoke(exception);
}
