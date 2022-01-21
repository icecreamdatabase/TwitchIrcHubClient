using System.Net.Http.Json;

namespace TwitchIrcHubClient.InternalApi.Connections;

public static class Connections
{
    private const string ControllerUri = "http://localhost:4721/Connection";

    public static async Task<bool> SetChannels(int botUserId, List<int> roomIds)
    {
        ConnectionRequestInput connectionRequestInput = new ConnectionRequestInput
        {
            BotUserId = botUserId,
            RoomIds = roomIds
        };
        HttpResponseMessage result = await InternalApiHelper.HttpClient.PutAsJsonAsync(ControllerUri, connectionRequestInput);
        return result.IsSuccessStatusCode;
    }
}