using System.Xml;
using System.Xml.Serialization;

namespace Loaders.Medium;
[XmlRoot("rss")]
public record RssFeed
{
    [property: XmlElement("channel")]
    public List<Channel> Channels { get; init; }

    public RssFeed()
    {
        Channels = [];
    }
}
