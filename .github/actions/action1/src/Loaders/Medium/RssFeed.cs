using System.Xml;
using System.Xml.Serialization;

[XmlRoot("rss")]
public record RssFeed {
    [property: XmlElement("channel")]
    public List<Channel> Channels {get; init;}
}
