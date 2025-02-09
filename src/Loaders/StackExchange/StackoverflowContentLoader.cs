using System.Net;
using System.Net.Http.Json;
using System.Text;

public class StackoverflowContentLoader : IContentLoader
{
    private const string StackExchangeApiUrl = "https://api.stackexchange.com/{0}/users/{1}{2}";
    private const string UserInfoApiUrl = "?page=1&pagesize=1&order=desc&sort=reputation&site=stackoverflow&filter=!LnNkvuC9lzrynVb9G.NQ4b";
    private const string UserActivityApiUrl = "/network-activity?page=1&pagesize=10&types=posts&filter=!2(C)X8o(hr(Y*aLv6ujVv";
    private const string OutputPattern = " - [{0} by {1} for {2}]({3})";
    private readonly string apiVersion;

    public StackoverflowContentLoader(string apiVersion = "2.3")
    {
        this.apiVersion = apiVersion;
    }

    public async Task<string> LoadAndParseContentAsync(string userId)
    {
        var users = await LoadFromStackExchangeApi<UserInfo>(GetUserInfoApiUrl(userId));
        if (!users.Any()) return string.Empty;

        var user = users[0];
        if (user == null) return string.Empty;

        var activities = await LoadFromStackExchangeApi<UserActivity>(GetUserActivityApiUrl(user.AccountId.ToString()));
        if (!activities.Any()) return string.Empty;

        var result = new StringBuilder();
        for (var i = 0; i < activities.Length; i += 1)
        {
            var activity = activities[i];
            result.AppendLine(string.Format(OutputPattern, GetActivityType(activity.ActivityType), user.DisplayName, activity.Title, activity.Link));
        }

        return result.ToString();
    }
    private string GetUserInfoApiUrl(string userId)
    {
        return string.Format(StackExchangeApiUrl, apiVersion, userId, UserInfoApiUrl);
    }
    private string GetUserActivityApiUrl(string accountId)
    {
        return string.Format(StackExchangeApiUrl, apiVersion, accountId, UserActivityApiUrl);
    }
    private static string GetActivityType(string type)
    {
        type = type.Replace("_posted", string.Empty);
        return type switch
        {
            "comment" => "Comment",
            "answer" => "Answer",
            "question" => "Ask",
            _ => string.Empty
        };
    }
    private static async Task<T[]> LoadFromStackExchangeApi<T>(string url)
    {
        using var handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip
        };
        using var httpClient = new HttpClient(handler);
        httpClient.DefaultRequestHeaders.Add("User-Agent", "GitHub Action for my own profile");
        
        var response = await httpClient.GetFromJsonAsync<ApiResponse<T>>(url);
        if (response != null && response.Items.Any())
        {
            return response.Items;
        }
        return Array.Empty<T>();
    }
}