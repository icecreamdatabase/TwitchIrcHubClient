using System.Net.Http.Json;
using Microsoft.AspNetCore.Http.Extensions;

namespace TwitchIrcHubClient.TwitchIrcHubApi.TwitchUsers;

public class TwitchUsers
{
    private readonly HttpClient _httpClient;
    private readonly string _hubRootUri;

    public TwitchUsers(HttpClient httpClient, string hubRootUri)
    {
        _httpClient = httpClient;
        _hubRootUri = hubRootUri;
    }

    private const string ControllerUriPart = "/TwitchUsers";

    public async Task<List<TwitchUsersResult>> Users(IEnumerable<string>? ids, IEnumerable<string>? logins)
    {
        ids ??= Enumerable.Empty<string>();
        logins ??= Enumerable.Empty<string>();

        string queryString = _hubRootUri + ControllerUriPart + new QueryBuilder { { "id", ids }, { "login", logins } };

        List<TwitchUsersResult>? twitchUsersResult =
            await _httpClient.GetFromJsonAsync<List<TwitchUsersResult>>(queryString);
        return twitchUsersResult ?? new List<TwitchUsersResult>();
    }

    public Task<Dictionary<string, string>> IdToLogin(IEnumerable<int> ids)
    {
        return IdToLogin(ids.Select(id => id.ToString()));
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public async Task<Dictionary<string, string>> IdToLogin(IEnumerable<string> ids)
    {
        string queryString = $"{ControllerUriPart}/IdToLogin{new QueryBuilder { { "id", ids } }}";

        Dictionary<string, string>? idToLoginDictionary =
            await _httpClient.GetFromJsonAsync<Dictionary<string, string>>(queryString);
        return idToLoginDictionary ?? new Dictionary<string, string>();
    }

    public async Task<Dictionary<string, string>> LoginToId(IEnumerable<string> logins)
    {
        string queryString = $"{ControllerUriPart}/LoginToId{new QueryBuilder { { "login", logins } }}";

        Dictionary<string, string>? idToLoginDictionary =
            await _httpClient.GetFromJsonAsync<Dictionary<string, string>>(queryString);
        return idToLoginDictionary ?? new Dictionary<string, string>();
    }
}
