using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.SignalR.Client;
using TwitchIrcHubClient.TwitchIrcHubApi;

namespace TwitchIrcHubClient;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class IrcHubClient
{
    [SuppressMessage("ReSharper", "PrivateFieldCanBeConvertedToLocalVariable")]
    private readonly HubConnection _hubConnection;
    public IncomingIrcEvents IncomingIrcEvents { get; }
    public OutgoingIrcEvents OutgoingIrcEvents { get; }
    public InternalApi Api { get; }

    public IrcHubClient(string appIdKey, string hubRootUri)
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl($"{hubRootUri}/IrcHub?appIdKey={appIdKey}")
            .WithAutomaticReconnect(new EndlessRetryPolicy())
            .Build();

        Api = new InternalApi(appIdKey);
        
        IncomingIrcEvents = new IncomingIrcEvents(_hubConnection);
        OutgoingIrcEvents = new OutgoingIrcEvents(_hubConnection);

        _hubConnection.Reconnected += HubConnectionOnReconnected;
        _hubConnection.Closed += HubConnectionOnClosed;

        _hubConnection.StartAsync();
    }

    private Task HubConnectionOnReconnected(string? arg)
    {
        Console.WriteLine($"Reconnected: {arg}");
        IncomingIrcEvents.HubConnectionOnReconnected(arg);
        return Task.CompletedTask;
    }

    private Task HubConnectionOnClosed(Exception? exception)
    {
        Console.WriteLine($"Closed: {exception}");
        IncomingIrcEvents.HubConnectionOnClosed(exception);
        return Task.CompletedTask;
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
