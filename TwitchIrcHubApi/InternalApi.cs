using System.Net.Http.Headers;

namespace TwitchIrcHubClient.TwitchIrcHubApi;

public class InternalApi
{
    private readonly HttpClient _httpClient = new();

    public readonly Connections.Connections Connections;
    public readonly TwitchUsers.TwitchUsers TwitchUsers;

    internal InternalApi(string appIdKey)
    {
        _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(appIdKey);
        Connections = new Connections.Connections(_httpClient);
        TwitchUsers = new TwitchUsers.TwitchUsers(_httpClient);
    }
}
