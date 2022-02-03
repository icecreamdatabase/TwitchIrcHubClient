using System.Net.Http.Json;

namespace TwitchIrcHubClient.TwitchIrcHubApi.Connections;

public class Connections
{
    private readonly HttpClient _httpClient;
    private readonly string _hubRootUri;

    public Connections(HttpClient httpClient, string hubRootUri)
    {
        _httpClient = httpClient;
        _hubRootUri = hubRootUri;
    }

    private const string ControllerUriPart = "/Connection";


    public async Task<bool> SetChannels(int botUserId, List<int> roomIds)
    {
        ConnectionRequestInput connectionRequestInput = new ConnectionRequestInput
        {
            BotUserId = botUserId,
            RoomIds = roomIds
        };
        HttpResponseMessage result =
            await _httpClient.PutAsJsonAsync(_hubRootUri + ControllerUriPart, connectionRequestInput);
        return result.IsSuccessStatusCode;
    }
}
