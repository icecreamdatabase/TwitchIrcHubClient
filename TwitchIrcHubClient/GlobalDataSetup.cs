namespace TwitchIrcHubClient;

public static class GlobalDataSetup
{
    private static string? _appIdKey;

    public static string AppIdKey
    {
        get =>  string.IsNullOrEmpty(_appIdKey) 
            ? throw new InvalidOperationException($"The {nameof(AppIdKey)} has never been set!") 
            : _appIdKey;
        set => _appIdKey = value;
    }
}
