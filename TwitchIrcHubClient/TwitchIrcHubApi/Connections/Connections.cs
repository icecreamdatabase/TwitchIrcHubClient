using System.Net.Http.Json;

namespace TwitchIrcHubClient.TwitchIrcHubApi.Connections;

public class Connections
{
    private readonly HttpClient _httpClient;

    public Connections(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private const string ControllerUri = "http://localhost:4721/Connection";
    

    public async Task<bool> SetChannels(int botUserId, List<int> roomIds)
    {
        ConnectionRequestInput connectionRequestInput = new ConnectionRequestInput
        {
            BotUserId = botUserId,
            RoomIds = roomIds
        };
        HttpResponseMessage result = await _httpClient.PutAsJsonAsync(ControllerUri, connectionRequestInput);
        return result.IsSuccessStatusCode;
    }
}