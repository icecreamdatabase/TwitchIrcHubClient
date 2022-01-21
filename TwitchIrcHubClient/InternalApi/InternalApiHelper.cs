using System.Net.Http.Headers;

namespace TwitchIrcHubClient.InternalApi;

public static class InternalApiHelper
{
    private static readonly HttpClient HttpClientInstance = new();

    internal static HttpClient HttpClient
    {
        get
        {
            if (!_isSetup)
                SetupHttpClient();
            return HttpClientInstance;
        }
    }

    private static bool _isSetup;

    private static void SetupHttpClient()
    {
        HttpClientInstance.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(GlobalDataSetup.AppIdKey);
        _isSetup = true;
    }
}
