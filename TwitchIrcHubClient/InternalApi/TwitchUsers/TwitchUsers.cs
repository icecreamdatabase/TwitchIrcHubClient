using System.Net.Http.Json;
using Microsoft.AspNetCore.Http.Extensions;

namespace TwitchIrcHubClient.InternalApi.TwitchUsers;

public static class TwitchUsers
{
    private const string ControllerUri = "http://localhost:4721/TwitchUsers";

    public static async Task<List<TwitchUsersResult>> Users(IEnumerable<string> ids, IEnumerable<string> logins)
    {
        string queryString = ControllerUri + new QueryBuilder { { "id", ids }, { "login", logins } };

        List<TwitchUsersResult>? twitchUsersResult =
            await InternalApiHelper.HttpClient.GetFromJsonAsync<List<TwitchUsersResult>>(queryString);
        return twitchUsersResult ?? new List<TwitchUsersResult>();
    }


    public static Task<Dictionary<string, string>> IdToLogin(IEnumerable<int> ids)
    {
        return IdToLogin(ids.Select(id => id.ToString()));
    }
    
    // ReSharper disable once MemberCanBePrivate.Global
    public static async Task<Dictionary<string, string>> IdToLogin(IEnumerable<string> ids)
    {
        string queryString = $"{ControllerUri}/IdToLogin{new QueryBuilder { { "id", ids } }}";

        Dictionary<string, string>? idToLoginDictionary =
            await InternalApiHelper.HttpClient.GetFromJsonAsync<Dictionary<string, string>>(queryString);
        return idToLoginDictionary ?? new Dictionary<string, string>();
    }

    public static async Task<Dictionary<string, string>> LoginToId(IEnumerable<string> logins)
    {
        string queryString = $"{ControllerUri}/LoginToId{new QueryBuilder { { "login", logins } }}";

        Dictionary<string, string>? idToLoginDictionary =
            await InternalApiHelper.HttpClient.GetFromJsonAsync<Dictionary<string, string>>(queryString);
        return idToLoginDictionary ?? new Dictionary<string, string>();
    }
}
