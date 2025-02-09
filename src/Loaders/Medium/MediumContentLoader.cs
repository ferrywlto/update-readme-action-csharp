using System.Text;
using System.Xml.Serialization;

namespace Loaders.Medium;
public class MediumContentLoader : IContentLoader
{
    private const string feedEndpoint = "https://medium.com/feed/@{0}";
    private const string OutputPattern = " - [{0}]({1})";

    public async Task<string> LoadAndParseContentAsync(string userId)
    {
        using var httpclient = new HttpClient();
        var url = GetRssFeedUrl(userId);

        var response = await httpclient.GetStreamAsync(url);

        if (response == null || !response.CanRead) return string.Empty;

        var xmlSerializer = new XmlSerializer(typeof(RssFeed));
        var feed = xmlSerializer.Deserialize(response) as RssFeed;

        if (feed == null) return string.Empty;
        if (feed.Channels[0] == null) return string.Empty;

        var stories = feed.Channels[0].Stories;
        var sb = new StringBuilder();
        stories.ForEach(story =>
        {
            sb.AppendLine(GetListStr(story));
        });

        return sb.ToString();
    }

    private static string GetRssFeedUrl(string userId) => string.Format(feedEndpoint, userId);
    private static string GetListStr(string title, string link) => string.Format(OutputPattern, title, link);
    private static string GetListStr(Story story) => GetListStr(story.Title, story.Link);
}